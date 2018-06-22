using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Core.Extensions;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.Enum;

namespace Tournaments.Data.Core.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<SeriesType> SeriesTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringProvider.GetSqlConnection());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureMatchRelations();
            modelBuilder.ConfigureTeamTournamentRelations();

            SeedEnumValues(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedEnumValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().SeedEnumEntities<Position, PositionEnum>(@enum => @enum);
            modelBuilder.Entity<SeriesType>().SeedEnumEntities<SeriesType, SeriesTypeEnum>(@enum => @enum);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}