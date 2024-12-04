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
        Task<IBusinessResult> CreatePlayer(PlayerCreateRequest playerCreateRequest);
        Task<IBusinessResult> UpdatePlayer(PlayerUpdateRequest playerUpdateRequest);
        Task<IBusinessResult> Save(Player player);
        Task<IBusinessResult> DeleteById(int id);
    }
}
