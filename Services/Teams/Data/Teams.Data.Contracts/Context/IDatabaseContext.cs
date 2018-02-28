using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Context
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