using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Club;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly SportShirtShopDBContext _context;
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _context = new SportShirtShopDBContext();
            _clubService = clubService;
        }
        // GET: api/<ClubController>
        [HttpGet]
        public async Task<IBusinessResult> GetAll()
        {
            return await _clubService.GetAll();
        }

        // GET api/<ClubController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetById(int id)
        {
            return await _clubService.GetById(id);
        }

        // POST api/<ClubController>
        [HttpPost]
        public async Task<IBusinessResult> Post(ClubCreateRequest clubCreateRequest)
        {
            return await _clubService.CreateClub(clubCreateRequest);
        }

        // PUT api/<ClubController>/5
        [HttpPut("{id}")]
        public async Task<IBusinessResult> Put(ClubUpdateRequets clubUpdateRequest)
        {
            return await _clubService.UpdateClub(clubUpdateRequest);
        }

        // DELETE api/<ClubController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var club = await _context.Accounts.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(club);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("listclub")]
        public async Task<IBusinessResult> Getlistclubname()
        {
            return await _clubService.GetClubName();        
        }
    }
}
