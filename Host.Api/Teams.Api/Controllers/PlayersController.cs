using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teams.Domain.Contracts;
using Teams.Dtos;

namespace Teams.Api.Controllers
{
    [Route("api/players")]
    public class PlayersController : Controller
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService playerService)
        {
            players = playerService;
        }

        [HttpGet("{id}", Name = "GetPlayerForTeam")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await players.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get(PagingParameter paging)
        {
            return Ok(await players.Get(paging));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PlayerForCreationDto playerForCreationDto)
        {
            var createdPlayer = await players.Create(playerForCreationDto);

            return CreatedAtRoute("GetPlayerForTeam",
                new { id = createdPlayer.Id },
                createdPlayer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await players.Delete(id);
            return NoContent();
        }
    }
}