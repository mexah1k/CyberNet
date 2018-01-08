using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Database.Abstractions.Context
{
    public interface IDatabaseContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }

        Task<int> SaveChangesAsync();
        void Dispose();
    }
}