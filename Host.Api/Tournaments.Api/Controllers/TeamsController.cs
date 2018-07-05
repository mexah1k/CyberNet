using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Team;

namespace Dota2.ProCircuit.Api.Controllers
{
    [Route("api/teams")]
    public class TeamsController : Controller
    {
        private readonly ITeamService teams;

        public TeamsController(ITeamService teamService)
        {
            teams = teamService;
        }

        [HttpGet("{id}", Name = "GetTeam")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await teams.Get(id));
        }

        [HttpGet(Name = "GetTeams")]
        public async Task<IActionResult> Get(PagingParameter paging)
        {
            return Ok(await teams.Get(paging));
        }

        [HttpGet("{id}/players", Name = "GetTeamPlayers")]
        public async Task<IActionResult> GetPlayers(int id, PagingParameter paging)
        {
            return Ok(await teams.GetPlayers(id, paging));
        }

        [HttpGet("{id}/tournaments", Name = "GetTeamTournaments")]
        public async Task<IActionResult> GetTournaments(int id, PagingParameter paging)
        {
            return Ok(await teams.GetTournaments(id, paging));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamForCreateDto teamForCreationDto)
        {
            var createdTeam = await teams.Create(teamForCreationDto);
            return CreatedAtRoute("GetTeam", new { id = createdTeam.Id }, createdTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await teams.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TeamForUpdateDto teamDto, int id)
        {
            await teams.Update(teamDto, id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] JsonPatchDocument<TeamForUpdateDto> teamDto, int id)
        {
            await teams.PartialUpdate(teamDto, id);
            return Ok();
        }
    }
}