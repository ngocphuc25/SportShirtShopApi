
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Payment;

namespace SWD.SportShirtShop.Services.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly UnitOfWork _unitOfWork;
        public PaymentService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var products = await _unitOfWork.Payment.GetAllAsync();
                if (products == null)
                {
                    return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG, products);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }
        public async Task<IBusinessResult> GetById(int id)
        {
            var customer = await _unitOfWork.Payment.GetByIdAsync(id);

            //  var product = customer.Adapt<ProductResponseForUser>();
            if (customer == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Shirt());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customer);
            }
        }

        public async Task<IBusinessResult> Create(PaymentCreateRequest request)
        {


            try
            {
                int result = 0;

                Payment payment = new Payment
                {
                    IdOrders = request.IdOrders,
                    Note= "duw",
                    Status = request.Status,
                    Method= request.Method,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };



                result = await _unitOfWork.Payment.CreateAsync(payment);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, payment);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, payment);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> UpdateStatusPayment(int IdPay, string status)
        {

            try
            {
                var payment = await _unitOfWork.Payment.GetByIdAsync(IdPay);
                int result = -1;

                if (payment != null)
                {
                    payment.Status = status;

                    result = await _unitOfWork.Payment.UpdateAsync(payment);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, payment);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, "Payment not found.");
                }

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        //public async Task<IBusinessResult> Save(Product product)
        //{
        //    try
        //    {
        //        int result = -1;
        //        var customerTmp = _unitOfWork.Product.GetById(product.IdProduct);
        //        if (customerTmp != null)
        //        {
        //            result = await _unitOfWork.Product.UpdateAsync(product);
        //            if (result > 0)
        //            {
        //                return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, product);
        //            }
        //            else
        //            {
        //                return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
        //            }
        //        }
        //        else
        //        {
        //            result = await _unitOfWork.Product.CreateAsync(product);
        //            if (result > 0)
        //            {
        //                return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, product);
        //            }
        //            else
        //            {
        //                return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, product);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
        //    }
        //}
        //public async Task<IBusinessResult> DeleteById(int id)
        //{
        //    try
        //    {
        //        var customer = await _unitOfWork.Product.GetByIdAsync(id);
        //        if (customer == null)
        //        {
        //            return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Product());
        //        }
        //        else
        //        {
        //            var result = await _unitOfWork.Product.RemoveAsync(customer);
        //            if (result)
        //            {
        //                return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, customer);
        //            }
        //            else
        //            {
        //                return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, customer);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
        //    }
        //}

    }
}
