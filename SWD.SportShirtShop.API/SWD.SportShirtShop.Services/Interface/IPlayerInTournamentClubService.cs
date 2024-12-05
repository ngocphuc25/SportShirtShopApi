using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using SWD.SportShirtShop.Services.RequetsModel.PlayerInTournamentClub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IPlayerInTournamentClubService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> CreatePlayerInTournamentClub(PlayerInTournamentClubCreateRequest playerInTournamentClubCreateRequest);
        Task<IBusinessResult> UpdatePlayerInTournamentClub(PlayerInTournamentClubUpdateRequest playerInTournamentClubUpdateRequest);
        Task<IBusinessResult> Save(PlayerInTournamentClub playerInTournamentClub);
        Task<IBusinessResult> DeleteById(int id);
    }
}
