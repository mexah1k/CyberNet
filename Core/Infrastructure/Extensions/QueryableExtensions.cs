using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedList<T>> ToPaginatedResult<T>(this IQueryable<T> query, PagingParameter paging)
        {
            var items = await query
                .Skip((paging.PageNumber - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToListAsync();

            return new PagedList<T>
            {
                Result = items,
                CurrentPage = paging.PageNumber,
                TotalPages = (int)Math.Ceiling(items.Count / (double)paging.PageSize),
                PageSize = paging.PageSize,
                TotalCount = items.Count
            };
        }
    }
}