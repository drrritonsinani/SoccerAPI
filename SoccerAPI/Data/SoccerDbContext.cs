using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoccerAPI.Configuration;
using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Data
{
    public class SoccerDbContext:IdentityDbContext<ApiUser>
    {
        public SoccerDbContext(DbContextOptions<SoccerDbContext> options) : base(options)
        {

        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<League>()
                
                .HasData(
                new League { LeagueId = 1, Name = "Premier League" },
                new League { LeagueId = 2, Name = "Seria A" },
                new League { LeagueId = 3, Name = "La Liga" }

            );


            modelBuilder.Entity<Team>().HasData(
               new Team { TeamId = 1, Name = "Team 1", LeagueId = 1 },
                new Team { TeamId = 2, Name = "Team 2", LeagueId = 2 },
                new Team { TeamId = 3, Name = "Team 3", LeagueId = 2 }

           );

           

            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 17, Name = "asd" },
                new Position { Id = 32, Name = "fgh" },
                new Position { Id = 44, Name = "dfg" }
           );

            modelBuilder.Entity<PlayerPosition>()
            .HasKey(pp => new { pp.PlayerId, pp.PositionId }
            );
        }
    }

   
}



