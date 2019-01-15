using Microsoft.EntityFrameworkCore;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.HelperTables;

namespace Tournaments.Data.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureMatchRelations(this ModelBuilder modelBuilder)
        {
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
        }

        public static void ConfigureTeamTournamentRelations(this ModelBuilder modelBuilder)
        {
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
        }
    }
}