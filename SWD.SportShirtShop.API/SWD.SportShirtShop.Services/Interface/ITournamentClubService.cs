using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.PlayerInTournamentClub;
using SWD.SportShirtShop.Services.RequetsModel.TournamentClub;
using SWD.SportShirtShop.Services.RequetsModel.TournammentClub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface ITournamentClubService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> CreateTournarmentClub(TournamentClubCreateRequest tournamentClubCreateRequest);
        Task<IBusinessResult> UpdateTournarmentClub(TournamentClubUpdateRequest tournamentClubUpdateRequest);
        Task<IBusinessResult> Save(Club club);
        Task<IBusinessResult> DeleteById(int id);
    }
}
