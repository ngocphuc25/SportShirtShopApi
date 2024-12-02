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
    public class AccountRepository : GenericRepository<Account>
    {
        private readonly SportShirtShopDBContext _dbContext;
        public AccountRepository() { }
        public AccountRepository(SportShirtShopDBContext dbContext) => _dbContext = dbContext; 

        public async Task<Account> FindOneAsync(string username, string password)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
        public async Task<Account> CheckCreateAsync(string email, string username)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == email && u.Username == username);
        }
    }
}
