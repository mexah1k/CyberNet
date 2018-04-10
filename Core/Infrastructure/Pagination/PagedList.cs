using System;
using System.Collections.Generic;

namespace Infrastructure.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; }

        public int TotalPages { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public bool HasPrevios => CurrentPage > 1;

        public PagedList(IEnumerable<T> listItems, int pageNumber, int pageSize, int count)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;

            AddRange(listItems);
        }
    }
}