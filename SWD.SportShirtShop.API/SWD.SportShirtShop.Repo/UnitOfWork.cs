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
        private ClubRepository _clubRepository;
        private TournamentRepository _tournamentRepository;
        private PlayerRepository _playerRepository;
        public UnitOfWork()
        {
            _unitOfWorkContext = new SportShirtShopDBContext();  
        }
        public AccountRepository Account
        {
            get { return _accountRepository ??= new AccountRepository(_unitOfWorkContext); }
        }
        public ClubRepository Club { get { return _clubRepository ??= new ClubRepository(_unitOfWorkContext); } }
        public PlayerRepository Player { get { return _playerRepository ??= new PlayerRepository(_unitOfWorkContext);} }
        public TournamentRepository Tournament { get { return _tournamentRepository ??= new TournamentRepository(_unitOfWorkContext); } }
    }
}
