using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using System.Security.Claims;


namespace SWD.SportShirtShop.Services.Interface
{
    public interface IClubService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Create(ClubCreateRequest clubCreateRequest, ClaimsPrincipal claim);
        Task<IBusinessResult> Update(ClubUpdateRequets clubUpdateRequets, ClaimsPrincipal claim);
        Task<IBusinessResult> Save(Club club);
        Task<IBusinessResult> DeleteById(int id);
    }
}
