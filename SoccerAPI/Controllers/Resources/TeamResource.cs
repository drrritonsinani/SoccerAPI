using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ManagerResource Manager { get; set; }
        public ICollection<PlayerResource2> Players { get; set; }

        public TeamResource()
        {
            Players = new Collection<PlayerResource2>();
            
        }
    }
}
