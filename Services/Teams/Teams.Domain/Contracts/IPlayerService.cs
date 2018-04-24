using Infrastructure.Pagination;
using System.Threading.Tasks;
using Teams.Dtos;

namespace Teams.Domain.Contracts
{
    public interface IPlayerService
    {
        Task<PlayerDto> Get(int id);
        Task<PlayerDto> Get(int teamId, int id);
        Task<PagedList<PlayerDto>> Get(PagingParameter paging, int teamId);
        Task<PlayerDto> Create(PlayerForCreationDto playerDto, int teamId);
        Task Delete(int playerId);
    }
}