using Infrastructure.Pagination;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedList<T> ToPaginatedResult<T>(this IQueryable<T> query, PagingParameter paging)
        {
            var items = query
                .Skip((paging.PageNumber - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToList();

            return new PagedList<T>(items, paging.PageNumber, paging.PageSize, query.Count());
        }
    }
}