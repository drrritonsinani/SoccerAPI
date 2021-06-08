using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string Location { get; set; }

        public int? LeagueId { get; set; }
        public League League { get; set; }

        public ICollection<Player> Players { get; set; }

    }
}
