using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.Enum;
using Tournaments.Data.Entities.HelperTables;

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
            // team and match relations | TODO: move to helper class
            modelBuilder.Entity<Match>()
                .HasOne(m => m.DireTeam)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.DireTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.RadiantTeam)
                .WithMany()
                .HasForeignKey(m => m.RadiantTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // team and tournaments relations (many-to-many) | TODO: move to helper class
            modelBuilder.Entity<TeamTournament>()
                .HasKey(t => new { t.TeamId, t.TournamentId });

            modelBuilder.Entity<TeamTournament>()
                .HasOne(t => t.Tournament)
                .WithMany(tr => tr.TeamTournament)
                .HasForeignKey(t => t.TournamentId);

            modelBuilder.Entity<TeamTournament>()
                .HasOne(tr => tr.Team)
                .WithMany(t => t.TeamTournament)
                .HasForeignKey(tr => tr.TeamId);

            modelBuilder.Entity<Position>().SeedEnumEntities<Position, PositionEnum>(@enum => @enum);

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}