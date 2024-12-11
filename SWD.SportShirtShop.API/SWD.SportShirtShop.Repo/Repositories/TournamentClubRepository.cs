using Microsoft.EntityFrameworkCore;
using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Repo.ResponseModel.TournamentClub;
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
        public async Task<TournamentClub> GetTournamentClubExist(int idclub, int idtournament)
        {
            return await _dbContext.TournamentClubs
        .FirstOrDefaultAsync(tc => tc.IdTournament == idtournament && tc.IdClub == idclub);



        }
        public async Task<List<TournamentClubListResponse>> GetListTournamentClubAsync()
        {
            return await _context.TournamentClubs
                .Select(tc => new TournamentClubListResponse
                {
                    Id = tc.Id,
                    IdTournament = tc.IdTournament,
                    IdClub = tc.IdClub,
                    CreateDate = tc.CreateDate,
                    TournamentName = tc.IdTournamentNavigation.Name,
                    ClubName = tc.IdClubNavigation.Name,
                    
                   // Assuming proper navigation
                })
                .ToListAsync();
        }
    }
}
