using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Repo
{
    public class UnitOfWork
    {
        private SportShirtShopDBContext _unitOfWorkContext;
        private AccountRepository _accountRepository;
        public UnitOfWork()
        {
            _unitOfWorkContext = new SportShirtShopDBContext();  
        }
        public AccountRepository Account
        {
            get { return _accountRepository ??= new AccountRepository(_unitOfWorkContext); }
        }

    }
}
