using Infrastructure.Extensions;
using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Repositories
{
    public class SeriesTypeRepository : ISeriesTypeRepository
    {
        private readonly IDataContext context;

        public SeriesTypeRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task<SeriesType> Get(int id)
        {
            return await context.SeriesTypes.GetOrThrow(id);
        }

        public async Task<PagedList<SeriesType>> Get(PagingParameter paging)
        {
            return await context.SeriesTypes.ToPaginatedResult(paging);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}