using System;
using System.Threading.Tasks;

namespace Tournaments.Data.Contracts.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }

        ITeamRepository Teams { get; }

        IPositionsRepository Positions { get; }

        IMatchRepository Matches { get; }

        ISeriesRepository Series { get; }

        ISeriesTypesRepository SeriesTypes { get; }

        ITournamentsRepository Tournaments { get; }

        Task<bool> SaveChangesAsync();
    }
}