using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Payment;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {   private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IPayosService _payosService;
        public  PaymentController(IPayosService payosService,IOrderService order, IPaymentService paymentService)
        {
            _paymentService=paymentService;
            _orderService=order;
            _payosService=payosService;
          
        }
        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaymentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("return_url")]
        public async Task<IActionResult> PayosReturnUrl(
    [FromQuery] string code,
    [FromQuery] string id,
    [FromQuery] string cancel,
    [FromQuery] string status,
    [FromQuery] string orderCode)
        {
            var querry = new PayosReturnUrl
            {
                Code = code,
                Id = id,
                Cancel = cancel,
                Status = status,
                OrderCode = orderCode
            };

            Console.WriteLine(querry.OrderCode);
             await _payosService.ReturnUrl(querry);
            // Extract claims from the current user (you might use User.Claims or HttpContext.User.Claims)

            // Call AddtoPayment with the extracted claims
            //   await _paymentService.Save(paymentResponseModel);
            /*  }
              else
              {
                  // Handle the failure case as needed
                  return BadRequest("Payment failed");
              }*/
              return Redirect("https://merci-7c36b.web.app/thankyou");
        }
    }
}
