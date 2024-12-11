using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.ResponseModel.Auth
{
    internal class AuthTokensResponse
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
