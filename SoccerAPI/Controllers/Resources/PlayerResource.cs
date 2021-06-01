using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Controllers.Resources
{
    public class PlayerResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; } //E.g: 1.87 (in meter)  
        public int Salary { get; set; }

        public ICollection<int> Positions { get; set; }

        public PlayerResource()
        {
            Positions = new Collection<int>();
        }

    }
}
