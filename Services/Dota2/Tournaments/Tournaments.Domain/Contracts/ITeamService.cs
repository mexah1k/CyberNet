using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Tournaments.Dtos;
using Tournaments.Dtos.Player;
using Tournaments.Dtos.Team;

namespace Tournaments.Domain.Contracts
{
    public interface ITeamService
    {
        Task<TeamDto> Get(int id);
        Task<PagedList<TeamDto>> Get(PagingParameter paging);
        Task<TeamDto> Create(TeamForCreateDto playerDto);
        Task Delete(int id);
        Task Update(TeamForUpdateDto teamDto, int id);
        Task PartialUpdate(JsonPatchDocument<TeamForUpdateDto> teamPatchDto, int id);
        Task<PagedList<PlayerDto>> GetPlayers(int id, PagingParameter paging);
    }
}