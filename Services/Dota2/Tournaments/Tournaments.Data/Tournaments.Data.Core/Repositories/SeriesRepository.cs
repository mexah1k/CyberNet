using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly IDataContext context;

        public SeriesRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Series> Get(int id)
        {
            return await context.Series
                .Include(s => s.Matches)
                .GetOrThrow(id);
        }

        public async Task<PagedList<Series>> Get(PagingParameter paging)
        {
            return await context.Series
                .Include(s => s.Matches)
                .ToPaginatedResult(paging);
        }

        public async Task Create(Series series)
        {
            Throw.IfNull(series, nameof(series));
            await context.Series.AddAsync(series);
        }

        public async Task Delete(int id)
        {
            var series = await Get(id);
            context.Series.Remove(series);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}