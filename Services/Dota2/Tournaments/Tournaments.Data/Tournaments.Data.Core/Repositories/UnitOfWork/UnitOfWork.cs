using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;

namespace Tournaments.Data.Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext context;

        public IPlayerRepository Players { get; }

        public ITeamRepository Teams { get; }

        public IPositionsRepository Positions { get; }

        public IMatchRepository Matches { get; }

        public ISeriesRepository Series { get; }

        public ISeriesTypesRepository SeriesTypes { get; }

        public ITournamentsRepository Tournaments { get; }

        public UnitOfWork(IDataContext dbcontext,
            IPlayerRepository players,
            ITeamRepository teams,
            IPositionsRepository positions, IMatchRepository matches, ISeriesRepository series,
            ISeriesTypesRepository seriesTypes, ITournamentsRepository tournaments)
        {
            context = dbcontext;
            Players = players;
            Teams = teams;
            Positions = positions;
            Matches = matches;
            Series = series;
            SeriesTypes = seriesTypes;
            Tournaments = tournaments;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Players?.Dispose();
            Teams?.Dispose();
            Positions?.Dispose();
            Matches?.Dispose();
            Series?.Dispose();
            SeriesTypes?.Dispose();
            Tournaments?.Dispose();
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}