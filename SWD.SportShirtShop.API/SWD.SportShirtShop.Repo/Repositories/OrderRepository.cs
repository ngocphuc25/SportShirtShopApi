using Microsoft.EntityFrameworkCore;
using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class OrderRepository :GenericRepository<Order>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public OrderRepository() { }
        public OrderRepository(SportShirtShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Order> GetOrderByOrderCode(string id)
        {
            return _context.Orders
               .Include(i => i.OrderDetails)
               .Include(i => i.Payments)
               .AsSplitQuery()
                .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Code == id)
               ;
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            return _context.Orders
                 .Include(i => i.OrderDetails)
                 .Include(i => i.Payments)
                 .AsSplitQuery()
                  .AsNoTracking()
                 .FirstOrDefault(o => o.Id == id)
                 ;
        }


        public async Task<int> SucessOrder()
        {
            int deliveredOrPaidOrdersCount = await _context.Orders
                .Where(o => o.Status == "đã giao" || o.PaymentStatus == "Thanh toán thành công")
                .CountAsync();

            return deliveredOrPaidOrdersCount;
        }
        public async Task<decimal?> TotalAmmount()
        {
            decimal? totalDeliveredOrPaidAmount = await _context.Orders
         .Where(o => o.Status == "Đã giao" || o.PaymentStatus == "Thanh toán thành công")
         .SumAsync(o => o.TotalAmmount);

            return totalDeliveredOrPaidAmount;
        }
        public async Task<List<Order>> GetProcessingOrdersAsync()
        {
            //var processingOrders = await _context.Orders
            //    .Where(o => o.PaymentStatus == "Chờ xác nhận")
            //    .ToListAsync();

            var orders = await _dbContext.Orders
                .Where(o => o.Status == "Chờ xác nhận")
                .Include(o => o.OrderDetails) // Nếu muốn lấy thêm chi tiết đơn hàng
                .ToListAsync();

            return orders;
        }
        public async Task<PaginatedResult<Order>> GetProcessingOrdersAsync(int pageNumber, int pageSize)
        {
            var query = _context.Orders.Where(o => o.Status == "Chờ xác nhận");

            var totalRecords = await query.CountAsync();
            var orders = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Order>
            {
                Data = orders,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _context.Orders
                .Where(o => o.Id == userId)
                .Include(o => o.OrderDetails) // Nếu muốn lấy thêm chi tiết đơn hàng
                .ToListAsync();

            return orders;
        }
    }


}
