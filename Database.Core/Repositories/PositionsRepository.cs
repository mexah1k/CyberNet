using Data.Abstractions.Context;
using Data.Abstractions.Repositories;
using Data.Entities.Team;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Core.Repositories
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