using Infrastructure.Pagination;
using System.Threading.Tasks;
using Teams.Dtos;

namespace Teams.Domain.Contracts
{
    public interface IPlayerService
    {
        Task<PlayerDto> Get(int id);
        Task<PagedList<PlayerDto>> Get(PagingParameter paging);
        Task<PlayerDto> Create(PlayerForCreationDto playerDto);
        Task Delete(int id);
        Task Update(int id);
    }
}