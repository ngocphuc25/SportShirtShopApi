﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Auth
{
    public class LoginRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; } = null;
    }
}
