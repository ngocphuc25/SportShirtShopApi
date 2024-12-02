using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Exceptions;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Auth;
using SWD.SportShirtShop.Services.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly TokenService _tokenService;

        public AuthController(IAuthService authService, TokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IBusinessResult> Login([FromBody] LoginRequest login)
        {
            return await _authService.Login(login);

        }

        [HttpPost("Register")]
        public async Task<IBusinessResult> Register([FromBody] RegisterRequest request)
        {
                var result = await _authService.RegisterAccount(request);
                if (result.Status == Const.SUCCESS_CREATE_CODE)
                {
                  return new BusinessResult(Const.SUCCESS_CREATE_CODE, "Đăng ký thành công. Vui lòng xác nhận email của bạn.");
                }
                return new BusinessResult(Const.FAIL_CREATE_CODE, "Đăng ký thất bại!!!!");

        }

        
       
    }
}
