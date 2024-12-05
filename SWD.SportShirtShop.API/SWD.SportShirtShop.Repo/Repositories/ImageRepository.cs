using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class ImageRepository : GenericRepository<Image>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public ImageRepository() { }
        public ImageRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext;
        
    }
}
