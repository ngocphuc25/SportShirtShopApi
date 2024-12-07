using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using SWD.SportShirtShop.Services.RequetsModel.ShirtEdition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IShirtEditionSerivice
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
       // Task<IBusinessResult> Save(ShirtEditionCreateRequest accountCustomer);
        Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> Create(ShirtEditionCreateRequest request);
        Task<IBusinessResult> Update(UpdateShirtEditionRequest clubUpdateRequets);
    }
}
