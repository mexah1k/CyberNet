using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; }

        public int TotalPages { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public bool HasPrevios => CurrentPage > 1;

        public PagedList(List<T> listItems, int pageNumber, int pageSize, int count)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;

            AddRange(listItems);
        }

        public static PagedList<T> CreatePagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, pageNumber, pageSize, source.Count());
        }
    }
}