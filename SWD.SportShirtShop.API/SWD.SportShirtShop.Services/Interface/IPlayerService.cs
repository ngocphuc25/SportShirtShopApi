using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IPlayerService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Save(Parallel accountCustomer);
        Task<IBusinessResult> DeleteById(int id);
    }
}
