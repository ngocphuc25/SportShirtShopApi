using Azure;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Net.payOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Core;
using System.Net;

using Microsoft.AspNetCore.Http;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Services.RequetsModel.Payment;


namespace SWD.SportShirtShop.Services.Service
{
    public class PayosService : IPayosService
    {
        private readonly IPaymentService _paymentService;
        private readonly UnitOfWork _unitOfWork;
        public PayosService(UnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }
        public async Task<IBusinessResult> Create(Order order)
        {
            // Keep your PayOS key protected by including it by an env variable
            var clientId = "77b6c318-7ab4-42ca-a40a-b67d7fa67582";
            var apiKey = "e213711a-2861-480a-ab5b-9a30e274965b";
            var checksumKey = "9e5d091a3db9b02b26398cd3b71ee5d96389f7f4aef98c207b5647e5a1d01fac";
            List<ItemData> data = new List<ItemData>();
            foreach (var item in order.OrderDetails)
            {
                data.Add(ConvertToItemData(item));
            }
            var payOS = new PayOS(clientId, apiKey, checksumKey);

             //var domain = "https://localhost:7036";
            var domain = "https://merciapp-e8cgheehc2bggzdv.japaneast-01.azurewebsites.net";
            var paymentLinkRequest = new PaymentData(
                orderCode: int.Parse(order.Code),
                amount: Convert.ToInt32(order.TotalAmmount),
                //  amount:2000,
                description: order.Code,
                items: data
                                ,
                returnUrl: domain + "/api/payment/return_url",
                cancelUrl: domain + "/api/payment/return_url"
            );
            CreatePaymentResult response = await payOS.createPaymentLink(paymentLinkRequest);

            return new BusinessResult(202, "create link success", response.checkoutUrl);
        }

        public ItemData ConvertToItemData(OrderDetail orderDetail)
        {
            return new ItemData
           (
        name: orderDetail.Name,  // Đảm bảo tên được truy cập đúng
        price: Convert.ToInt32(orderDetail.Price),  // Chuyển đổi giá
        quantity: orderDetail.Quantity.Value  // Sử dụng số lượng
          );
        }

        public async Task<IBusinessResult> ReturnUrl(PayosReturnUrl querry)
        {
            //var querry = new PayosReturnUrl
            //{
            //    Code = queryParams["code"].ToString(),
            //    Id = queryParams["id"].ToString(),
            //    Cancel = queryParams["cancel"].ToString(),
            //    Status = queryParams["status"].ToString(),
            //    OrderCode = queryParams["orderCode"].ToString()
            //};
            //Console.WriteLine( querry );
            var order = await _unitOfWork.Order.GetOrderByOrderCode(querry.OrderCode);
           
            if (order == null)
            {
                throw new Exception("Không có idOrder");
            }
           Console.WriteLine(order.TotalAmmount);
           PaymentCreateRequest payment = new PaymentCreateRequest
            {
                IdOrders = order.Id,
              
                Method = "Thanh toán Payos",
                Status = querry.Status,
                Price= order.TotalAmmount,  
            };
            if (querry.Code == "00" && querry.Status == "PAID")
            {
                payment.Status = "Thanh toán thành công";
            }
            else
            {
                payment.Status = "Thanh toán thất bại";
                order.Status = "Đã hủy thanh toán";
            }
            order.PaymentStatus = payment.Status;
       
            await _unitOfWork.Order.UpdateAsync(order);

            var savePayment = await _paymentService.Create(payment);
            if (querry.Code == "00" && querry.Status == "PAID")
            {
                return new BusinessResult(Const.SUCCESS_CREATE_CODE, "Thanh toán thành công");
            }
            else
            {
                return new BusinessResult(Const.FAIL_CREATE_CODE, "Thanh toán thất bại");
            }

        }
    }
}
