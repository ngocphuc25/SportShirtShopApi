using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;

namespace SWD.SportShirtShop.Repo.ResponseModel.Shirt
{
    public class ShirtList
    {
        public int Id { get; set; }

        public int? IdShirtEdition { get; set; }

        public int? IdPlayerinTournamentClub { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? SalePrice { get; set; }
        public string Status { get; set; }


        public int? IdPlayer { get; set; }

        public int Number { get; set; }

        public string PlayerName { get; set; }

        public string SeasonName { get; set; }

        public string ClubName { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
