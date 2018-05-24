using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Context
{
    public interface IDataContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Position> Positions { get; set; }

        Task<int> SaveChangesAsync();
        void Dispose();
    }
}