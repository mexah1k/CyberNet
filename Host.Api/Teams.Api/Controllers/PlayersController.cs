using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teams.Domain.Contracts;
using Teams.Dtos;

namespace Teams.Api.Controllers
{
    [Route("api/teams/{teamId}/players")]
    public class PlayersController : Controller
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService players)
        {
            this.players = players;
        }

        [HttpGet("{id}", Name = "GetPlayerForTeam")]
        public async Task<IActionResult> Get(int teamId, int id)
        {
            return Ok(await players.Get(teamId, id));
        }

        [HttpGet]
        public async Task<IActionResult> Get(PagingParameter paging, int teamId)
        {
            return Ok(await players.Get(paging, teamId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(int teamId, [FromBody]PlayerForCreationDto playerForCreationDto)
        {
            var createdPlayer = await players.Create(playerForCreationDto, teamId);

            return CreatedAtRoute("GetPlayerForTeam",
                new { teamId, id = createdPlayer.Id },
                createdPlayer);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await players.Delete(id);
        }
    }
}