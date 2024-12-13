using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Player
{
    public class PlayerCreateRequest
    {
        

        public int? IdClub { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public string? Note { get; set; }

        public string Code { get; set; }
        public int? CreateAccount { get; set; }
    }
}
