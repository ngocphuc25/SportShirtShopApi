using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.ShirtEdition
{
    public class UpdateShirtEditionRequest
    {
        public int Id { get; set; }

        public int? IdTournament { get; set; }

        public string Nameseason { get; set; }

        public string Status { get; set; }

        public string Note { get; set; }

        public string Code { get; set; }
    }
}
