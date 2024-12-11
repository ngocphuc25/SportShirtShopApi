using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Shirt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IShirtService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Create(ShirtCreateRequest request);
        Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> Update(ShirtUpdateRequest request);
        Task<IBusinessResult> GetAllShirtsWithImagesAsync();
    }
}
