using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<League> Leagues { get; }
        IGenericRepository<Team> Teams { get; }
        IGenericRepository<Player> Players { get; }
        IGenericRepository<Position> Positions { get; }

        Task Save();

    }
}
