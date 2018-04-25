using Infrastructure.Extensions;
using System;
using System.Threading.Tasks;
using Teams.Data.Contracts.Context;
using Teams.Data.Contracts.Repositories;
using Teams.Data.Entities;

namespace Teams.Data.Core.Repositories
{
    public class PositionsRepository : IPositionsRepository
    {
        private readonly IDataContext context;

        public PositionsRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Position> Get(int id)
        {
            return await context.Positions.GetOrThrow(id);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}