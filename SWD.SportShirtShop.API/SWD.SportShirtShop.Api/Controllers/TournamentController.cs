using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using SWD.SportShirtShop.Services.RequetsModel.Tournament;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly SportShirtShopDBContext _context;
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            _context = new SportShirtShopDBContext();
            _tournamentService = tournamentService;
        }

        // GET: api/<TournamentController>
        [HttpGet]
        public async Task<IBusinessResult> Get()
        {
            return await _tournamentService.GetAll();
        }

        // GET api/<TournamentController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> Get(int id)
        {
            return await _tournamentService.GetById(id);
        }

        // POST api/<TournamentController>
        [HttpPost]
        public async Task<IBusinessResult> Post(TournamentCreateRequest tournamentCreateRequest)
        {
            return await _tournamentService.CreateTournament(tournamentCreateRequest);
        }

        // PUT api/<TournamentController>/5
        [HttpPut("{id}")]
        public async Task<IBusinessResult> Put(TournamentUpdateRequest tournamentUpdateRequest)
        {
            return await _tournamentService.UpdateTournament(tournamentUpdateRequest);
        }

        // DELETE api/<TournamentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tournament = await _context.Accounts.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(tournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
