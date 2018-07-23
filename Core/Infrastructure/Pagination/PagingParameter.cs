using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Pagination
{
    public class PagingParameter
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 250)]
        public int PageSize { get; set; } = 250;
    }
}