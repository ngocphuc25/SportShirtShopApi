using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Common.Exceptions;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Order;
using SWD.SportShirtShop.Services.RequetsModel.Shirt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Service
{
    public class OrderService :IOrderService
    {
        private readonly IOrderService _orderService;
        private readonly UnitOfWork _unitOfWork;
        private static Random random = new Random();
        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IBusinessResult> GetAll()
        {
            var categories = await _unitOfWork.Shirt.GetAllAsync();
            if (categories != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, categories);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var account = await _unitOfWork.Shirt.GetByIdAsync(id);
            if (account == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, account);
            }
        }

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var account = await _unitOfWork.Shirt.GetByIdAsync(id);
                if (account == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    int result = -1;
                    //     account.Status = "Deleted";
                    result = await _unitOfWork.Shirt.UpdateAsync(account);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, account);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, account);
                    }

                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> CreateOrder(CreateOrderRequest request)
        {
            try
            {
                
                int result = -1;
                //var userId = claim.FindFirst("id")?.Value;

                string status = "Chờ xác nhận";
                string paymentStatus = "Chưa thanh toán";
                var idAccount = _unitOfWork.Account.GetById(request.IdAccount.Value);
                if (idAccount == null) { request.IdAccount = null; }

                foreach (var item in request.Items)
                {
                    // Lấy thông tin sản phẩm từ cơ sở dữ liệu
                    var product = await _unitOfWork.Shirt.GetByIdAsync(item.IdProduct);

                    // Kiểm tra sản phẩm có tồn tại không
                    if (product == null)
                    {
                        throw new BadRequestException($"Sản phẩm với ID {item.IdProduct} không tồn tại.");
                    }

                    // Kiểm tra số lượng hàng tồn kho
                    if (item.Quantity > product.QuantityStock)
                    {
                        throw new BadRequestException($"Số lượng sản phẩm {product.Name} không đủ. Còn lại {product.QuantityStock} sản phẩm.");

                    }

                    // Kiểm tra số lượng đặt hàng hợp lệ
                    if (item.Quantity <= 0)
                    {
                        continue; // Bỏ qua mục có số lượng <= 0
                    }
                    product.TotalSold = product.TotalSold + item.Quantity;
                    // Cập nhật số lượng hàng tồn kho sau khi thêm vào đơn hàng
                    product.QuantityStock = product.QuantityStock - item.Quantity;


                }
                _unitOfWork.SaveChangesWithTransaction();
                Order newOrder = new Order
                {
                    IdAccount = request.IdAccount,
                    Code = GenerateOrderCode(8),
                    Name=request.Name,
                    PaymentMethod=request.PaymentMethod,
                    CreateDate = DateTime.Now,
                    Status = status,
                    PaymentStatus = "Chưa thanh toán",
                    Note = request.Note,
                    ShipAddress = request.ShipAddress,
                    TotalAmmount = request.TotalAmmount,
                    


                };
                decimal totalAmount = 0;
                foreach (var item in request.Items)
                {
                    var product = _unitOfWork.Shirt.GetById(item.IdProduct);
                    if (item.Quantity <= 0)
                    {
                        // Bạn có thể bỏ qua mục này hoặc trả về lỗi tùy theo yêu cầu
                        continue; // Bỏ qua mục có số lượng <= 0
                                  // Hoặc:
                                  // return new BusinessResult(Const.FAIL_CREATE_CODE, "Số lượng sản phẩm phải lớn hơn 0.", order1);
                    }

                    var orderDetail = new OrderDetail
                    {
                        IdShirt = product.Id,
                        Quantity = item.Quantity,
                       
                        Price = product.Price,
                        SalePrice = product.SalePrice,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };
                    decimal? detailAmount = (orderDetail.SalePrice.HasValue && orderDetail.SalePrice > 0
                            ? orderDetail.SalePrice.Value
                            : orderDetail.Price) * orderDetail.Quantity;
                    orderDetail.Subtotal=detailAmount;
                    totalAmount += detailAmount.Value;

                    newOrder.OrderDetails.Add(orderDetail);
                }
                newOrder.TotalAmmount = totalAmount;
                result = await _unitOfWork.Order.CreateAsync(newOrder);


                if (result > 0)

                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, newOrder);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, newOrder);
                }

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(ShirtUpdateRequest request)
        {
            try
            {
                int result = -1;
                //var userId = claim.FindFirst("id")?.Value;
                //if (userId == null)
                //{
                //    return new BusinessResult(Const.ERROR_EXCEPTION, "Do not have idUser");
                //}
                var club = _unitOfWork.Shirt.GetById(request.Id);


                // var update = request.Adapt<Shirt>();


                if (club != null)
                {
                    //result = await _unitOfWork.Shirt.UpdateAsync(update);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, club);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, "NOT FOUND ID");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }
        public static string GenerateOrderCode(int length = 8)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
