using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Club
{
    public class ClubCreateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public string Status { get; set; }

        public string? Note { get; set; }

        public string Code { get; set; }
        public DateTime? CreateDate { get; set; }

        public int? CreateAccount { get; set; }


    }

}
