using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teams.Domain.Contracts;

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

        /*
        [HttpPost]
        public async Task<IActionResult> Create(int teamId, [FromBody]PlayerForCreationDto playerForCreationDto)
        {
            if (playerForCreationDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            if (!unitOfWork.Teams.IsExist(teamId).Result)
                return NotFound("Team not found"); // todo: move message to resource file

            var player = Map(playerForCreationDto);
            await unitOfWork.Players.Add(player);

            if (!await unitOfWork.SaveChangesAsync())
                return BadRequest("Creation failed."); // todo: move message to resource file

            return CreatedAtRoute("GetPlayerForTeam",
                new { teamId, id = player.Id },
                Map(player));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await unitOfWork.Players.Delete(id);
        }*/
    }
}