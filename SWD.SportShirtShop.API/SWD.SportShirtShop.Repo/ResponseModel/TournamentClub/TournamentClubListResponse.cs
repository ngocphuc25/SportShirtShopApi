using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.ResponseModel.TournamentClub
{
    public class TournamentClubListResponse
    {
        public int Id { get; set; }

        public int? IdTournament { get; set; }

        public int? IdClub { get; set; }

        public DateTime? CreateDate { get; set; }
        public string TournamentName { get; set; }
        public string ClubName { get; set; }
    }
}
