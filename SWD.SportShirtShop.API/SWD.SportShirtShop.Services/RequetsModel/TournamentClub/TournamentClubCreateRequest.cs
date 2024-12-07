using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.TournamentClub
{
    public class TournamentClubCreateRequest
    {
        public int Id { get; set; }

        public int? IdTournament { get; set; }

        public int? IdClub { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateAccount { get; set; }
    }
}
