﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.RequetsModel.Tournament
{
    public class TournamentCreateRequest
    {
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

        public string Code { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateAccount { get; set; }
    }
}
