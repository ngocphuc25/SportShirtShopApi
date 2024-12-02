using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IAuthService
    {
        Task<IBusinessResult> Login(LoginRequest request);
        Task<IBusinessResult> RegisterAccount(RegisterRequest request);
    }
}
