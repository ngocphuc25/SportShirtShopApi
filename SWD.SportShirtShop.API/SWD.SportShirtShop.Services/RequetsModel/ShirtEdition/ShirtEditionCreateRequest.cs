using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.ShirtEdition
{
    public class ShirtEditionCreateRequest
    {
        

        public int IdTournamentClub { get; set; }

 
        public string Color { get; set; }

        public string Material { get; set; }

        public string VersionForMatch { get; set; }
        public string Status { get; set; }

        public string Note { get; set; }

        public string Code { get; set; }
        public int? CreateAccount { get; set; }
    }
}
