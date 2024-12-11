using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.ResponseModel.Auth
{
    public class RegisterResponse
    {
        public required string AccessToken { get; set; }

        public required string RefreshToken { get; set; }
    }
}
