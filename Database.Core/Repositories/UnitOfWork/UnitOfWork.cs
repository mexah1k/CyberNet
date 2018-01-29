using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Abstractions.Repositories.UnitOfWork;
using System.Threading.Tasks;

namespace Database.Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext context;

        public IPlayerRepository Players { get; }

        public ITeamRepository Teams { get; }

        public IPositionsRepository Positions { get; }

        public UnitOfWork(IDatabaseContext context,
            IPlayerRepository players,
            ITeamRepository teams,
            IPositionsRepository positions)
        {
            this.context = context;
            Players = players;
            Teams = teams;
            Positions = positions;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}