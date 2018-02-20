using AutoMapper;
using Data.Abstractions.Repositories.UnitOfWork;
using Data.Entities.Entities;
using Dtos.Team;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Api.Controllers
{
    [Route("api/teams/{teamId}/players")]
    public class PlayersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlayersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetPlayerForTeam")]
        public async Task<IActionResult> Get(int teamId, int id)
        {
            var player = await unitOfWork.Players.GetPlayerByTeam(teamId, id);

            return Ok(Map(player));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int teamId)
        {
            var players = await unitOfWork.Players.GetPlayersByTeam(teamId);

            return Ok(players.Select(Map));
        }

        [HttpPost]
        public async Task<IActionResult> Create(int teamId, [FromBody]PlayerForCreationDto playerForCreationDto)
        {
            if (playerForCreationDto == null)
                return BadRequest();

            if (!await unitOfWork.Teams.IsExist(teamId))
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
        public async Task<IActionResult> Delete(int teamId, int id)
        {
            if (!await unitOfWork.Teams.IsExist(teamId))
                return NotFound("Team not found");

            await unitOfWork.Players.Delete(id);

            if (!await unitOfWork.SaveChangesAsync())
                return BadRequest("Deleting failed."); // todo: move message to resource file

            return NoContent();
        }

        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int teamId, int id, [FromBody] PlayerForUpdateDto player)
        {
            if (player == null)
                return BadRequest();
            
        }*/

        private PlayerDto Map(Player source)
        {
            return mapper.Map<PlayerDto>(source);
        }

        private Player Map(PlayerForCreationDto source)
        {
            return mapper.Map<Player>(source);
        }
    }
}