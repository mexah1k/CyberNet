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

        public UnitOfWork(IDataContext dbcontext,
            IPlayerRepository players,
            ITeamRepository teams,
            IPositionsRepository positions)
        {
            context = dbcontext;
            Players = players;
            Teams = teams;
            Positions = positions;
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
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}