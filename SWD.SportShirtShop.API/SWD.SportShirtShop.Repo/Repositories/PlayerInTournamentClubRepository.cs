using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class PlayerInTournamentClubRepository : GenericRepository<PlayerInTournamentClub>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public PlayerInTournamentClubRepository() { }
        public PlayerInTournamentClubRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext;


    }
}
