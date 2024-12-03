using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Repo.Repositories;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IClubService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Save(ClubCreateRequest accountCustomer);
        Task<IBusinessResult> DeleteById(int id);
    }
}
