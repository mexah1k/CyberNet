using Infrastructure.Pagination;
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
        Task Update(int id);
    }
}