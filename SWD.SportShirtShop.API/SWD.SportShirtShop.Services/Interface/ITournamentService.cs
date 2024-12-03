using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Player;
using SWD.SportShirtShop.Services.RequetsModel.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface ITournamentService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Create(TournamentCreateRequest tournamentCreateRequest, ClaimsPrincipal claim);
        Task<IBusinessResult> Update(TournamentUpdateRequest tournamentUpdateRequets, ClaimsPrincipal claim);
        Task<IBusinessResult> Save(Tournament tournament);
        Task<IBusinessResult> DeleteById(int id);
    }
}
