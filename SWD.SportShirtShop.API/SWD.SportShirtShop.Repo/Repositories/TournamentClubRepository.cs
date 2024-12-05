using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class TournamentClubRepository : GenericRepository<TournamentClub>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public TournamentClubRepository() { }
        public TournamentClubRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext;
    }
}
