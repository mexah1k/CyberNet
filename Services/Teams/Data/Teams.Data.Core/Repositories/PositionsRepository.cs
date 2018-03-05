using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Teams.Data.Contracts.Context;
using Teams.Data.Contracts.Repositories;
using Teams.Data.Entities;

namespace Teams.Data.Core.Repositories
{
    public class PositionsRepository : IPositionsRepository
    {
        private readonly IDatabaseContext context;

        public PositionsRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<Position> Get(int id)
        {
            return await context.Positions.SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}