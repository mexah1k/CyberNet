using System.Threading.Tasks;
using Infrastructure.Pagination;
using Tournaments.Dtos.SeriesType;

namespace Tournaments.Domain.Contracts
{
    public interface ISeriesTypeService
    {
        Task<SeriesTypeDto> Get(int id);
        Task<PagedList<SeriesTypeDto>> Get(PagingParameter paging);
    }
}