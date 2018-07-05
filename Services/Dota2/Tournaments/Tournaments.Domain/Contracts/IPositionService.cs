using Infrastructure.Pagination;
using System.Threading.Tasks;
using Tournaments.Dtos.Position;

namespace Tournaments.Domain.Contracts
{
    public interface IPositionService
    {
        Task<PositionDto> Get(int id);

        Task<PagedList<PositionDto>> Get(PagingParameter paging);
    }
}