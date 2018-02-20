using Data.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Abstractions.Context
{
    public interface IDatabaseContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Position> Positions { get; set; }

        Task<int> SaveChangesAsync();
        void Dispose();
    }
}