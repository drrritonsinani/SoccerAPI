using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public string Nationality { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; } //E.g: 1.87 (in meter)  
        public int Salary { get; set; }

        public ICollection<PlayerPosition> Positions { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public Player()
        {
            Positions = new Collection<PlayerPosition>();
        }
    }
}
