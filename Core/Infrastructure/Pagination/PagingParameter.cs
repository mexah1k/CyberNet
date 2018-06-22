using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Pagination
{
    public class PagingParameter
    {
        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; }

        [Range(0, 250)]
        public int PageSize { get; set; }
    }
}