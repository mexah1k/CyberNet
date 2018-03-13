using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Teams.Data.Contracts.Context;
using Teams.Data.Entities;

namespace Teams.Data.Core.Context
{
    public class ApplicationDbContext : DbContext, IDatabaseContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Entities.Team> Teams { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringProvider.GetSqlConnection());
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}