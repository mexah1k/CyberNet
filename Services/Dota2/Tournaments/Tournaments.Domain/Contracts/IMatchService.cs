using Infrastructure.Pagination;
using System.Threading.Tasks;
using Tournaments.Dtos.Match;

namespace Tournaments.Domain.Contracts
{
    public interface IMatchService
    {
        Task<MatchDto> Get(int id);

        Task<PagedList<MatchDto>> Get(PagingParameter paging);

        Task<MatchDto> Create(MatchForCreateDto matchDto);

        Task Delete(int id);

        Task Update(MatchForUpdateDto matchForUpdateDto, int id);
    }
}