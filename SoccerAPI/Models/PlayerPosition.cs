using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Models
{
   
    public class PlayerPosition
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
