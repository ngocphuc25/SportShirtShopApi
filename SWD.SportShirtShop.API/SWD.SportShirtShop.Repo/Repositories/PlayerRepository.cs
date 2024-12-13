using Microsoft.EntityFrameworkCore;
using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Repo.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class PlayerRepository : GenericRepository<Player>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public PlayerRepository() { }
        public PlayerRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext;
        public async Task<List<NameReponse>> GetListPlayerName()
        {
            var querry = _context.Players.Select(tc => new NameReponse { id = tc.Id, Name = tc.Name });


            return await querry.ToListAsync();
        }
    }
}
