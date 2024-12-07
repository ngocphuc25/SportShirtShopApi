using Microsoft.AspNetCore.Http;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IPayosService
    {
        Task<IBusinessResult> Create(Order order);
        Task<IBusinessResult> ReturnUrl(PayosReturnUrl queeryy);
    }
}
