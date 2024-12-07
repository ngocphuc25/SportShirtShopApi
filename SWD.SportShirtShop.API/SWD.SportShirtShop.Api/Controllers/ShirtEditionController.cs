using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.ShirtEdition;
using SWD.SportShirtShop.Services.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtEditionController : ControllerBase
    {
        // GET: api/<ShirtEditionController>
        private IShirtEditionSerivice _shirtEditionSerivce;
        public ShirtEditionController(IShirtEditionSerivice shirtEditionSerivce) { _shirtEditionSerivce = shirtEditionSerivce; }
        [HttpGet]
        public async Task<IBusinessResult> GetAll ()
        {
            return await  _shirtEditionSerivce.GetAll();
        }

        // GET api/<ShirtEditionController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetByID(int id)
        {
            return await _shirtEditionSerivce.GetById(id);
        }

        // POST api/<ShirtEditionController>
        [HttpPost]
        public async Task<IBusinessResult> Post([FromBody] ShirtEditionCreateRequest value)
        {
            return await _shirtEditionSerivce.Create(value);
        }

        // PUT api/<ShirtEditionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShirtEditionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
