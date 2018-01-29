using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Database.Core.Repositories
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
    }
}