using Infrastructure.Pagination;
using System.Threading.Tasks;
using Tournaments.Dtos.Series;

namespace Tournaments.Domain.Contracts
{
    public interface ISeriesService
    {
        Task<SeriesDto> Get(int id);
        Task<PagedList<SeriesDto>> Get(PagingParameter paging);
        Task<SeriesDto> Create(SeriesForCreateDto seriesDto);
        Task Delete(int id);
        Task Update(SeriesForUpdateDto seriesForUpdateDto, int id);
    }
}