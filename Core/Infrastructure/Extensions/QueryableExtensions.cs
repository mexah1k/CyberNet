using Infrastructure.Exceptions;
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
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((paging.PageNumber - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToListAsync();

            return new PagedList<T>
            {
                Result = items,
                CurrentPage = paging.PageNumber,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paging.PageSize),
                PageSize = paging.PageSize,
                TotalCount = totalCount
            };
        }

        public static async Task<T> GetOrThrow<T>(this IQueryable<T> query, int itemId) where T : IKeyIdentifier
        {
            T result = await query.FirstOrDefaultAsync(item => item.Id == itemId);

            if (result == null)
            {
                throw new ItemNotFoundException(typeof(T).Name, itemId);
            }

            return result;
        }
    }
}