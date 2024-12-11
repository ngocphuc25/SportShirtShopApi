using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Shirt
{
    public class ShirtCreateRequest
    {
        public int? IdShirtEdition { get; set; }

        public int? IdPlayerinTournamentClub { get; set; }
        public decimal? SalePrice { get; set; }
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public int? QuantityStock { get; set; }

        public string Status { get; set; }

        public string Code { get; set; }

        public int? CreateAccount { get; set; }

        public List<ListImage> links { get; set; }
        
    }
}
