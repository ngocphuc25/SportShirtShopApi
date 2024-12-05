using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Image;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/<ImageController>
        [HttpGet]
        public async Task<IBusinessResult> Get()
        {
            return await _imageService.GetAll();
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> Get(int id)
        {
            return await _imageService.GetById(id);
        }

        // POST api/<ImageController>
        [HttpPost]
        public async Task<IBusinessResult> Post(ImageCreateRequest imageCreateRequest)
        {
            return await _imageService.CreateImage(imageCreateRequest);
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public async Task<IBusinessResult> Put(ImageUpdateRequest imageUpdateRequest)
        {
            return await _imageService.UpdateImage(imageUpdateRequest);
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> Delete(int id)
        {
            return await _imageService.DeleteById(id);
        }
    }
}
