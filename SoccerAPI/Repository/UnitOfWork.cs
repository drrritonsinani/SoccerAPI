using SoccerAPI.Data;
using SoccerAPI.IRepository;
using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoccerDbContext context;
        public IGenericRepository<League> leagues { get; set; }
        public IGenericRepository<Team> teams { get; set; }
        public IGenericRepository<Player> players { get; set; }
        public IGenericRepository<Position> positions { get; set; }

        public UnitOfWork(SoccerDbContext context)
        {
            this.context = context;
        }
        public IGenericRepository<League> Leagues => leagues ??= new GenericRepository<League>(context);

        public IGenericRepository<Team> Teams => teams ??= new GenericRepository<Team>(context);
        public IGenericRepository<Player> Players => players ??= new GenericRepository<Player>(context);

        public IGenericRepository<Position> Positions => positions ??= new GenericRepository<Position>(context);

        public void Dispose()
        {
            context.Dispose();
            System.GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
