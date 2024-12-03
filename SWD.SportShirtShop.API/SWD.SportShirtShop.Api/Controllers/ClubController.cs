using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Repo.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly SportShirtShopDBContext _context;
        public ClubController(SportShirtShopDBContext context)
        {
            _context = context;
        }
        // GET: api/<ClubController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClubController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClubController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClubController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClubController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
