using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Tournaments.Dtos;
using Tournaments.Dtos.Player;

namespace Tournaments.Domain.Contracts
{
    public interface IPlayerService
    {
        Task<PlayerDto> Get(int id);
        Task<PagedList<PlayerDto>> Get(PagingParameter paging);
        Task<PlayerDto> Create(PlayerForCreationDto playerDto);
        Task Delete(int id);
        Task Update(PlayerForUpdateDto playerDto, int id);
        Task PartialUpdate(JsonPatchDocument<PlayerForUpdateDto> playerPatchDto, int id);
    }
}