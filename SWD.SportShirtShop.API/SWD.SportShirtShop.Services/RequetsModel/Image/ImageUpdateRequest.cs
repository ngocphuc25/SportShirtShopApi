using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Image
{
    public class ImageUpdateRequest
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public int? IdShirt { get; set; }
    }
}
