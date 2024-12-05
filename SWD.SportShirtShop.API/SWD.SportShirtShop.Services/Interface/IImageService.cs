 using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using SWD.SportShirtShop.Services.RequetsModel.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IImageService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> CreateImage(ImageCreateRequest imaggeCreateRequest);
        Task<IBusinessResult> UpdateImage(ImageUpdateRequest imageUpdateRequest);
        Task<IBusinessResult> Save(Image image);
        Task<IBusinessResult> DeleteById(int id);
    }
}
