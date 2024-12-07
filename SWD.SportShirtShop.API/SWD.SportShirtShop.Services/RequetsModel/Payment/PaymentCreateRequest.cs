using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Payment
{
    public class PaymentCreateRequest
    {

        public int? IdOrders { get; set; }

        public string Method { get; set; }

        public string Status { get; set; }

        public decimal? Price { get; set; }

        public string Note { get; set; }

    }
}
