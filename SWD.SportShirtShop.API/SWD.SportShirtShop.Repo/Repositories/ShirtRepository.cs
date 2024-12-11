using Microsoft.EntityFrameworkCore;
using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Repo.ResponseModel.Shirt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class ShirtRepository :GenericRepository<Shirt>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public ShirtRepository() { }
        public ShirtRepository(SportShirtShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Shirt>> GetAllShirtsWithImagesAsync()
        {
            var shirts = await _context.Shirts
                .Include(s => s.Images) // Include để lấy danh sách Images liên kết
                .ToListAsync();

            // Chuyển đổi sang DTO để trả về kết quả
           

            return shirts;
        }

        public async Task<Shirt> GetByIdAsync(int id)
        {
            return await _context.Shirts
                .Include(s => s.Images) // Tải danh sách Images liên quan
                .FirstOrDefaultAsync(s => s.Id == id); // Lọc theo Id
        }
        public async Task<List<ShirtList>> GetShirtList()
        {
            return await _context.Shirts
                .Select(tc => new ShirtList
                {
                    Id = tc.Id,
                    IdPlayerinTournamentClub = tc.IdPlayerinTournamentClub,
                    IdPlayer = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.IdPlayer : null,
                    IdShirtEdition = tc.IdShirtEdition,
                    Name= tc.Name,
                    Price = tc.Price,
                    SalePrice = tc.SalePrice,
                    ClubName = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.ClubName : null,
                    PlayerName = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.PlayerName : null,
                    Number = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.Number : 0, // Default to 0
                    SeasonName = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.SeasonName : null,
                    Status =tc.Status,
                    Images = tc.Images,
                    // Assuming proper navigation
                })
                .ToListAsync();
        }
    }
}
