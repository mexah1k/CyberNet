using System.Threading.Tasks;
using Teams.Data.Contracts.Context;
using Teams.Data.Contracts.Repositories;
using Teams.Data.Contracts.Repositories.UnitOfWork;

namespace Teams.Data.Core.Repositories.UnitOfWork
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
    }
}