using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Teams.Dtos;

namespace Teams.Domain.Contracts
{
    public interface ITeamService
    {
        Task<TeamDto> Get(int id);
        Task<PagedList<TeamDto>> Get(PagingParameter paging);
        Task<TeamDto> Create(TeamForCreationDto playerDto);
        Task Delete(int id);
        Task Update(TeamForUpdateDto teamDto, int id);
        Task PartialUpdate(JsonPatchDocument<TeamForUpdateDto> teamPatchDto, int id);
    }
}