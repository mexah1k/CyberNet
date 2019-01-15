using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.HelperTables;

namespace Tournaments.Data.Contracts.Context
{
    public interface IDataContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Tournament> Tournaments { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<Series> Series { get; set; }
        DbSet<SeriesType> SeriesTypes { get; set; }
        DbSet<TeamTournament> TeamTournament { get; set; }

        Task<int> SaveChangesAsync();
        void Dispose();
    }
}