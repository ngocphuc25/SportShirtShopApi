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
        private ShirtRepository _shirtRepository;
        private ShirtEditionRepository _shirtEditionRepository;
        private OrderRepository _orderRepository;
        private PaymentRepository _paymentRepository;
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
        public ShirtEditionRepository ShirtEdition { get { return _shirtEditionRepository ??= new ShirtEditionRepository(_unitOfWorkContext); } }
        public ShirtRepository Shirt { get {return _shirtRepository ??= new ShirtRepository(_unitOfWorkContext); }}
        public OrderRepository Order { get { return _orderRepository ??= new OrderRepository(_unitOfWorkContext);} }
        public PaymentRepository Payment { get { return _paymentRepository ??= new PaymentRepository(_unitOfWorkContext); } }   
        
        private PlayerInTournamentClubRepository _playerInTournamentClubRepository;
        private TournamentClubRepository _tournamentClubRepository;
        private ImageRepository _imageRepository;

     
        public TournamentClubRepository TournamentClub { get { return _tournamentClubRepository ??= new TournamentClubRepository(_unitOfWorkContext); } }
        public ImageRepository Image { get { return _imageRepository ??= new ImageRepository(_unitOfWorkContext); } }
        public PlayerInTournamentClubRepository PlayerInTournamentClub { get{ return _playerInTournamentClubRepository ??= new PlayerInTournamentClubRepository(_unitOfWorkContext); } }
        
        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = _unitOfWorkContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = await _unitOfWorkContext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
    
}
