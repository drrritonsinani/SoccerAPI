using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Models
{
    public class Position
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string Name { get; set; }

    
    }
}
