using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Shirt;
using SWD.SportShirtShop.Services.RequetsModel.ShirtEdition;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtController : ControllerBase
    {
        private readonly IShirtService _shirtService;
        public ShirtController(IShirtService shirtService)
        {
            _shirtService = shirtService;
        }
        // GET: api/<ShirtController>
        [HttpGet]
        public async Task<IBusinessResult> GetAll()
        {
            return await _shirtService.GetAll();
        }
        [HttpGet("list")]
        public async Task<IBusinessResult> GetShirtList()
        {
            return await _shirtService.GetShirtList();
        }
        // GET api/<ShirtEditionController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetByID(int id)
        {
            return await _shirtService.GetById(id);
        }

        // POST api/<ShirtEditionController>
        [HttpPost]
        public async Task<IBusinessResult> Post([FromBody] ShirtCreateRequest value)
        {
            return await _shirtService.Create(value);
        }

        // PUT api/<ShirtController>/5
        [HttpPut]
        public async Task<IBusinessResult> Put([FromBody] ShirtUpdateRequest  value)
        {
            return await _shirtService.Update(value);
        }

        // DELETE api/<ShirtController>/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> Delete(int id)
        {
            return await _shirtService.DeleteById(id);
        }
    }
}
