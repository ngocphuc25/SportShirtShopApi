using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.ResponseModel
{
    public class DashboardInfo
    {
        public int TotalOrderCompleted { get; set; }
        public decimal? TotalAmmount { get; set; }
        public int TotalProduct { get; set; }
    }
}
