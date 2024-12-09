﻿using Microsoft.EntityFrameworkCore;
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
    }
}
