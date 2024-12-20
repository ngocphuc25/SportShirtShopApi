﻿using Microsoft.EntityFrameworkCore;
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
    public class ClubRepository : GenericRepository<Club>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public ClubRepository() { }
        public ClubRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext;


        public async Task<List<Club>> GetAllAsync()
        {
            return await _context.Clubs .Include(c => c.TournamentClubs)
        .ThenInclude(tc => tc.IdTournamentNavigation).ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(c => c.TournamentClubs)
       .ThenInclude(tc => tc.IdTournamentNavigation).FirstOrDefaultAsync(o => o.Id==id); ;
        }

        public async Task<List<NameReponse>> GetListClubName()
        {
            var querry= _context.Clubs.Select(tc =>new NameReponse { id=tc.Id,Name=tc.Name});


            return await querry.ToListAsync();
        }
    }
}
