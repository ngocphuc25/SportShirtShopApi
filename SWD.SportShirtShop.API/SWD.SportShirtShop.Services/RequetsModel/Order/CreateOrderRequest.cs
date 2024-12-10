using SWD.SportShirtShop.Services.RequetsModel.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Order
{
    public class CreateOrderRequest
    {

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }


        public string Note { get; set; }


        public int? IdAccount { get; set; }

        public string PaymentMethod { get; set; }

        public string ShipAddress { get; set; }


        public required List<OrderDetailsRequest> Items { get; set; }

    }
}
