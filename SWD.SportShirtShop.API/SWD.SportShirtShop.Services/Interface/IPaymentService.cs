
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IPaymentService
    {
        Task<IBusinessResult> Create(PaymentCreateRequest request);
        Task<IBusinessResult> UpdateStatusPayment(int IdPay, string status);
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> GetAll();
    }
}
