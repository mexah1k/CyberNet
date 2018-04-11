using System.Collections.Generic;

namespace Infrastructure.Pagination
{
    public class PagedList<T>
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;

        public IEnumerable<T> Result { get; set; }
    }
}