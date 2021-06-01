using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
