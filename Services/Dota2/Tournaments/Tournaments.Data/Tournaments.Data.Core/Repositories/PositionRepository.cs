using Infrastructure.Extensions;
using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Repositories
{
    public class PositionRepository : IPositionsRepository
    {
        private readonly IDataContext context;

        public PositionRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Position> Get(int id)
        {
            return await context.Positions.GetOrThrow(id);
        }

        public async Task<PagedList<Position>> Get(PagingParameter paging)
        {
            return await context.Positions.ToPaginatedResult(paging);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}