using SWD.SportShirtShop.Repo.Base;
using SWD.SportShirtShop.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo.Repositories
{
    public class PaymentRepository :GenericRepository<Payment>
    {
        public PaymentRepository() { }
        private readonly SportShirtShopDBContext _dbContext;
        private readonly UnitOfWork _unitOfWork;
        public PaymentRepository(SportShirtShopDBContext dBContext)
        {
            _dbContext = dBContext;
        }
    }
}
