using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SportShirtShopDBContext _context;
        private readonly IAccountService _iAccountService;
        public AccountController(IAccountService iAccountService)
        {
            _context = new SportShirtShopDBContext();
            _iAccountService = iAccountService;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public async Task<IBusinessResult> GetAllAccount()
        {
            var accounts = await _iAccountService.GetAll();
            return accounts;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetAccount(int id)
        {
            var acc = await _iAccountService.GetById(id);
            if (acc == null)
            {
                return (IBusinessResult)NotFound();
            }
            return acc;
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IBusinessResult> PostAccount(Account account)
        {
            

            return await _iAccountService.Save(account);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutAcount(int id, Account account)
        {
            account.Id = id;
            return await _iAccountService.Save(account);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
