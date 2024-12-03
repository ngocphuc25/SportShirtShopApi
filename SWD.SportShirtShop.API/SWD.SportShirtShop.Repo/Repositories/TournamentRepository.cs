using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class TournamentRepository : GenericRepository<Tournament>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public TournamentRepository() { }
        public TournamentRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext;
    }
}
