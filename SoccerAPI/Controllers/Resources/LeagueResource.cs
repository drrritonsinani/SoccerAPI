﻿using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Controllers.Resources
{
    public class LeagueResource
    {
        public int LeagueId { get; set; }
       
        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<string> Teams { get; set; }
    }
}
