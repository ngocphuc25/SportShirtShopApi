using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.OrderDetail
{
    public class OrderDetailsRequest
    {
        [Required]
        public int IdProduct { get; set; }

        [Required]
        public int Quantity { get; set; }


        //public int? Price { get; set; }

        //public int? SalePrice { get; set; }

    }
}
