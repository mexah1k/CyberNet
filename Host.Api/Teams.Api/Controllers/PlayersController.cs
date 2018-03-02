using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Teams.Data.Contracts.Repositories.UnitOfWork;
using Teams.Data.Entities;
using Teams.Dtos;

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

            if (player == null)
                return NotFound();

            return Ok(Map(player));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int teamId)
        {
            var players = await unitOfWork.Players.GetPlayersByTeam(teamId);

            if (players == null)
                return NotFound();

            return Ok(players.Select(Map));
        }

        [HttpPost]
        public async Task<IActionResult> Create(int teamId, [FromBody]PlayerForCreationDto playerForCreationDto)
        {
            if (playerForCreationDto == null)
                return BadRequest();

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
        }

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