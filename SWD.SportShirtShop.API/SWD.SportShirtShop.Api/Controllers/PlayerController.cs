using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Player;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly SportShirtShopDBContext _context;
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _context = new SportShirtShopDBContext();
            _playerService = playerService;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<IBusinessResult> Get()
        {
            return await _playerService.GetAll();
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> Get(int id)
        {
            return await _playerService.GetById(id);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public async Task<IBusinessResult> Post(PlayerCreateRequest playerCreateRequest)
        {
            return await _playerService.CreatePlayer(playerCreateRequest);
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public async Task<IBusinessResult> Put(PlayerUpdateRequest playerUpdateRequest)
        {
            return await _playerService.UpdatePlayer(playerUpdateRequest);
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
