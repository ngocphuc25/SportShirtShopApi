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

        public int? IdUser { get; set; }

        //    public required string OrderCode { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string ShippingAddress { get; set; }

        public required decimal TotalAmount { get; set; }

        public required string OrderType { get; set; }

        //   public required string PaymentStatus { get; set; }

        public required List<OrderDetailsRequest> Item { get; set; }

        public string? Note { get; set; }

    }
}
