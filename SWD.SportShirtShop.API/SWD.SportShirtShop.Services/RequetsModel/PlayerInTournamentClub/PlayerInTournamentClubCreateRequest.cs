using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.PlayerInTournamentClub
{
    public class PlayerInTournamentClubCreateRequest
    {
        public int Id { get; set; }

        public int? IdTournamentClub { get; set; }

        public int? IdPlayer { get; set; }

        public int? Number { get; set; }

        public string PlayerName { get; set; }

        public string SeasonName { get; set; }

        public string ClubName { get; set; }

        public string Description { get; set; }
    }
}
