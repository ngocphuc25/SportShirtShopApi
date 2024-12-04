using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using SWD.SportShirtShop.Services.RequetsModel.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IPlayerService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Create(PlayerCreateRequest playerCreateRequest, ClaimsPrincipal claim);
        Task<IBusinessResult> Update(PlayerUpdateRequest playerUpdateRequets, ClaimsPrincipal claim);
        Task<IBusinessResult> Save(Player player);
        Task<IBusinessResult> DeleteById(int id);
    }
}
