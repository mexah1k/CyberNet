using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournaments.Dtos.Series;
using Tournaments.Dtos.Team;
using Tournaments.Dtos.Tournament;

namespace Tournaments.Domain.Contracts
{
    public interface ITournamentService
    {
        Task<TournamentDto> Get(int id);

        Task<PagedList<TournamentDto>> Get(PagingParameter paging);

        Task<PagedList<TeamDto>> GetTeams(int id, PagingParameter paging);

        Task<PagedList<SeriesDto>> GetSeries(int id, PagingParameter paging);

        Task<TournamentDto> Create(TournamentForCreateDto tournamentDto);

        Task Delete(int id);

        Task Update(TournamentForUpdateDto tournamentDto, int id);

        Task PartialUpdate(JsonPatchDocument<TournamentForUpdateDto> tournamentPatchDto, int id);

        Task AddTeams(IEnumerable<int> teamIds, int id);
    }
}