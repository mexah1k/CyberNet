using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Tournament;

namespace Dota2.ProCircuit.Api.Controllers
{
    [Route("api/tournaments")]
    public class TournamentsController : Controller
    {
        private readonly ITournamentService tournaments;

        public TournamentsController(ITournamentService tournamentService)
        {
            tournaments = tournamentService;
        }

        [HttpGet("{id}", Name = "GetTournament")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await tournaments.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get(PagingParameter paging)
        {
            return Ok(await tournaments.Get(paging));
        }

        [HttpGet("{id}/teams", Name = "GetTournamentTeams")]
        public async Task<IActionResult> GetTeams(int id, PagingParameter paging)
        {
            return Ok(await tournaments.GetTeams(id, paging));
        }

        [HttpGet("{id}/series", Name = "GetTournamentSeries")]
        public async Task<IActionResult> GetSeries(int id, PagingParameter paging)
        {
            return Ok(await tournaments.GetSeries(id, paging));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TournamentForCreateDto tournamentForCreationDto)
        {
            var createdTournament = await tournaments.Create(tournamentForCreationDto);
            return CreatedAtRoute("GetTournament", new { id = createdTournament.Id }, createdTournament);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await tournaments.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TournamentForUpdateDto tournamentDto, int id)
        {
            await tournaments.Update(tournamentDto, id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] JsonPatchDocument<TournamentForUpdateDto> tournamentDto, int id)
        {
            await tournaments.PartialUpdate(tournamentDto, id);
            return Ok();
        }
    }
}