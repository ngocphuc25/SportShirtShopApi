using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.TournamentClub;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentClubController : ControllerBase
    {

        private readonly ITournamentClubService _tournamentClubService;
        public TournamentClubController(ITournamentClubService tournamentClubService)
        {
            _tournamentClubService = tournamentClubService;
        }
            // GET: api/<TournamentClubController>
            [HttpGet]
        public async Task<IBusinessResult> Get()
        {
            return await _tournamentClubService.GetAll();
        }

        // GET api/<TournamentClubController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> Get(int id)
        {
            return await _tournamentClubService.GetById(id);
        }

        // POST api/<TournamentClubController>
        [HttpPost]
        public async Task<IBusinessResult> Post(TournamentClubCreateRequest tournamentClubCreateRequest)
        {
            return await _tournamentClubService.CreateTournarmentClub(tournamentClubCreateRequest);
        }

        // PUT api/<TournamentClubController>/5
        [HttpPut("{id}")]
        public async Task<IBusinessResult> Put(TournamentClubUpdateRequest tournamentClubUpdateRequest)
        {
            return await _tournamentClubService.UpdateTournarmentClub(tournamentClubUpdateRequest);
        }

        // DELETE api/<TournamentClubController>/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> Delete(int id)
        {
            return await _tournamentClubService.DeleteById(id); 
        }
    }
}
