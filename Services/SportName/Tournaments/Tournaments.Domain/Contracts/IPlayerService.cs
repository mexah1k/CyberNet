using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Dtos.Player;

namespace Tournaments.Domain.Contracts
{
    public interface IPlayerService
    {
        Task<PlayerDto> Get(int id);

        Task<PagedList<PlayerDto>> Get(PagingParameter paging, PlayerFilter filter);

        Task<PlayerDto> Create(PlayerForCreateDto playerDto);

        Task Delete(int id);

        Task Update(PlayerForUpdateDto playerDto, int id);

        Task PartialUpdate(JsonPatchDocument<PlayerForUpdateDto> playerPatchDto, int id);
    }
}