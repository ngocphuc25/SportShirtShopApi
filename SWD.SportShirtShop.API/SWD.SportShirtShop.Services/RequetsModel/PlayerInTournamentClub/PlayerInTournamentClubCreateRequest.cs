using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.PlayerInTournamentClub
{
    public class PlayerInTournamentClubCreateRequest
    {
      

        public int IdTournamentClub { get; set; }

        public int IdPlayer { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }
    }
}
