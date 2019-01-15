using System;
using System.Threading.Tasks;

namespace Tournaments.Data.Contracts.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }

        ITeamRepository Teams { get; }

        IPositionRepository Position { get; }

        IMatchRepository Matches { get; }

        ISeriesRepository Series { get; }

        ISeriesTypeRepository SeriesType { get; }

        ITournamentRepository Tournament { get; }

        Task<bool> SaveChangesAsync();
    }
}