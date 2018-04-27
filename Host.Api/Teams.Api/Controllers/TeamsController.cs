using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teams.Domain.Contracts;
using Teams.Dtos;

namespace Teams.Api.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamForCreationDto teamForCreationDto)
        {
            var createdTeam = await teams.Create(teamForCreationDto);

            return CreatedAtRoute("GetTeam", new { id = createdTeam.Id }, createdTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await teams.Delete(id);
            return NoContent();
        }
    }
}