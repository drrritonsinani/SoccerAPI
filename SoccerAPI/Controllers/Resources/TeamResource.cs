using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Controllers.Resources
{
    public class TeamResource
    {
        public int TeamId { get; set; }
       
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string Location { get; set; }

        public Manager Manager { get; set; }
        public ICollection<PlayerResource> Players { get; set; }
    }
}
