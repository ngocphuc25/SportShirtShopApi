using Mapster;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Exceptions;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Auth;
using SWD.SportShirtShop.Services.ResponseModel.Auth;


namespace SWD.SportShirtShop.Services.Service
{
    public class AuthService : IAuthService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly TokenService _tokenService;

        AuthService()
        {

        }
        AuthService(UnitOfWork unitOfWork, TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<IBusinessResult> Login(LoginRequest request)
        {
            var account = await _unitOfWork.Account.FindOneAsync(request.UserName, request.Password);

            if (account is null)
            {
                throw new UnauthorizedAccessException("Wrong email or password");
            }
            if (account.Status != "ACTIVE")
            {
                throw new UnauthorizedAccessException("Tài khoản chưa kích hoạt");
            }
            AuthTokensResponse respone = new AuthTokensResponse();

            respone.AccessToken = _tokenService.GenerateAccessToken(account.Id, account.Role, account.Name, account.Email, account.Phone);
            respone.RefreshToken = _tokenService.GenerateRefreshToken();

            return new BusinessResult(Const.SUCCESS_CREATE_CODE, "Login success", respone);
        }

        public async Task<IBusinessResult> RegisterAccount(RegisterRequest request)
        {
            var account = await _unitOfWork.Account.FindOneAsync(a => a.Email == request.Email);

            if (account is not null)
            {
                throw new BadRequestException("Account with this email already exists");
            }


            var newAccount = request.Adapt<Account>();
            newAccount.Status = "ACTIVE";
            newAccount.Role = null;
            //newAccount.Password = HashPassword(request.Password);
            var ac = await _unitOfWork.Account.CreateAsync(newAccount);
            var account1 = await _unitOfWork.Account.FindOneAsync(a => a.Email == request.Email);

            if (account1 == null)
            {
                return new BusinessResult(Const.FAIL_CREATE_CODE, "Can not create");
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_CREATE_CODE, "", account1);
            }
        }
    }
}
