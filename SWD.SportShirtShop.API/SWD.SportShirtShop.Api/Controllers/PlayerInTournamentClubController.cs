using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.PlayerInTournamentClub;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerInTournamentClubController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IPlayerInTournamentClubService _playerInTournamentClubService;
        public PlayerInTournamentClubController(IPlayerInTournamentClubService playerInTournamentClubService) { _playerInTournamentClubService = playerInTournamentClubService; }
        // GET: api/<PlayerInTournamentClubController>
        [HttpGet]
        public async Task<IBusinessResult> Get()
        {
            return await _playerInTournamentClubService.GetAll();
        }

        // GET api/<PlayerInTournamentClubController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> Get(int id)
        {
            return await _playerInTournamentClubService.GetById(id);
        }

        // POST api/<PlayerInTournamentClubController>
        [HttpPost]
        public async Task<IBusinessResult> Post(PlayerInTournamentClubCreateRequest playerInTournamentClubCreateRequest)
        {
            return await _playerInTournamentClubService.CreatePlayerInTournamentClub(playerInTournamentClubCreateRequest);
        }

        // PUT api/<PlayerInTournamentClubController>/5
        [HttpPut("{id}")]
        public async Task<IBusinessResult> Put(PlayerInTournamentClubUpdateRequest playerInTournamentClubUpdateRequest)
        {
            return await _playerInTournamentClubService.UpdatePlayerInTournamentClub(playerInTournamentClubUpdateRequest);
        }

        // DELETE api/<PlayerInTournamentClubController>/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> Delete(int id)
        {
            return await _playerInTournamentClubService.DeleteById(id);
        }
    }
}
