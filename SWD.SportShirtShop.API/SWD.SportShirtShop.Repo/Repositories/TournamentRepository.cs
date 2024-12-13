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
    public class TournamentRepository : GenericRepository<Tournament>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public TournamentRepository() { }
        public TournamentRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext;
        public async Task<List<NameReponse>> GetListTournamentName()
        {
            var querry = _context.Tournaments.Select(tc => new NameReponse { id = tc.Id, Name = tc.Name });


            return await querry.ToListAsync();
        }
    }
}
