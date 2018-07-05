using Infrastructure.Exceptions;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedList<T>> ToPaginatedResult<T>(this IQueryable<T> query, PagingParameter paging)
        {
            var items = await GetPagedList(query, paging);

            var totalCount = await query.CountAsync();

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

        private static async Task<IList<T>> GetPagedList<T>(IQueryable<T> query, PagingParameter paging)
        {
            // TODO: RETURN ALL LIST IF PAGING PARAMETER EMPTY
            //if (paging.PageNumber == 0 && paging.PageSize == 0)
            //    return await query.ToListAsync();

            return await query
                .Skip((paging.PageNumber - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToListAsync();
        }
    }
}