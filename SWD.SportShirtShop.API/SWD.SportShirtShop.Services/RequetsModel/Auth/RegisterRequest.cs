using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Auth
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; } = null!;
        public string Name { get; set; }
        public string Phone { get; set; }

        
    }
}
