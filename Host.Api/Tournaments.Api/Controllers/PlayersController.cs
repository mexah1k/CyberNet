using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos;
using Tournaments.Dtos.Player;

namespace Dota2.ProCircuit.Api.Controllers
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
        public async Task<IActionResult> Create([FromBody]PlayerForCreateDto playerDto)
        {
            var createdPlayer = await players.Create(playerDto);

            return CreatedAtRoute("GetPlayerForTeam",
                new { id = createdPlayer.Id },
                createdPlayer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await players.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PlayerForUpdateDto playerDto, int id)
        {
            await players.Update(playerDto, id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] JsonPatchDocument<PlayerForUpdateDto> playerDto, int id)
        {
            await players.PartialUpdate(playerDto, id);

            return Ok();
        }
    }
}