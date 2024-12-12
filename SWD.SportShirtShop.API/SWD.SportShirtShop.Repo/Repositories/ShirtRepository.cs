using Microsoft.EntityFrameworkCore;
using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Repo.ResponseModel;
using SWD.SportShirtShop.Repo.ResponseModel.Shirt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


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
        public async Task<List<Shirt>> GetAllAsync()
        {
            var shirts = await _context.Shirts
                .Include(s => s.Images) // Include để lấy danh sách Images liên kết
                .ToListAsync();

            // Chuyển đổi sang DTO để trả về kết quả


            return shirts;
        }

        public async Task<int> CountProductsByConditionAsync()
        {
            int productCount = await _context.Shirts
                .CountAsync();
            return productCount;
        }
        public async Task<Shirt> GetByIdAsync(int id)
        {
            return await _context.Shirts
                .Include(s => s.Images) // Tải danh sách Images liên quan
                .FirstOrDefaultAsync(s => s.Id == id); // Lọc theo Id
        }
        public async Task<PaginatedResponse<ShirtList>> GetShirtList(string playerName = null,
    string seasonName = null,
    int? number = null,
    string clubName = null, int pageNumber = 1,
    int pageSize = 10)
        {
            //var query = await _context.Shirts
            //    .Select(tc => new ShirtList
            //    {
            //        Id = tc.Id,
            //        IdPlayerinTournamentClub = tc.IdPlayerinTournamentClub,
            //        IdPlayer = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.IdPlayer : null,
            //        IdShirtEdition = tc.IdShirtEdition,
            //        Name= tc.Name,
            //        Price = tc.Price,
            //        SalePrice = tc.SalePrice,
            //        ClubName = tc.IdShirtEditionNavigation.IdTournamentClubNavigation.IdClubNavigation.Name ,
            //        PlayerName = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.PlayerName : null,
            //        Number = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.Number : 0, // Default to 0
            //        SeasonName = tc.IdShirtEditionNavigation.Nameseason,
            //        Status =tc.Status,  
            //        Images = tc.Images,
            //        // Assuming proper navigation
            //    })
            //    .ToListAsync();

            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Clamp(pageSize, 1, 100);
            var query = _context.Shirts
          .Select(tc => new ShirtList
          {
              Id = tc.Id,
              IdPlayerinTournamentClub = tc.IdPlayerinTournamentClub,
              IdPlayer = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.IdPlayer : null,
              IdShirtEdition = tc.IdShirtEdition,
              Name = tc.Name,
              Price = tc.Price,
              SalePrice = tc.SalePrice,
              ClubName = tc.IdShirtEditionNavigation.IdTournamentClubNavigation.IdClubNavigation.Name,
              PlayerName = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.PlayerName : null,
              Number = tc.IdPlayerinTournamentClubNavigation != null ? tc.IdPlayerinTournamentClubNavigation.Number : 0,
              SeasonName = tc.IdShirtEditionNavigation.Nameseason,
              Status = tc.Status,
              Images = tc.Images,
          });

            // Apply filters if parameters are provided
            if (!string.IsNullOrEmpty(playerName))
            {
                query = query.Where(s => s.PlayerName.Contains(playerName));
            }

            if (!string.IsNullOrEmpty(seasonName))
            {
                query = query.Where(s => s.SeasonName.Contains(seasonName));
            }

            if (number.HasValue)
            {
                query = query.Where(s => s.Number == number.Value);
            }

            if (!string.IsNullOrEmpty(clubName))
            {
                query = query.Where(s => s.ClubName.Contains(clubName));
            }
            int totalCount = await query.CountAsync();

            var paginatedResults = await query
      .Skip((pageNumber - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();
            return new PaginatedResponse<ShirtList>
            {
                Items = paginatedResults,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            }; // Explicitly convert to List


        }
    }
}
