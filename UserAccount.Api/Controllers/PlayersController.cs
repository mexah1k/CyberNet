using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Abstractions.Repositories.UnitOfWork;
using Database.Entities.Entities;
using Mapper.Dtos.Team;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await unitOfWork.Players.Get(id);

            if (user == null) return NotFound();

            return Ok(Map(user));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await unitOfWork.Players.Get();

            if (users == null) return NotFound();

            return Ok(users.Select(Map));
        }

        // POST api/players
        [HttpPost]
        public async Task Post([FromBody]PlayerDto player)
        {
            await unitOfWork.Players.Add(Map(player));
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await unitOfWork.Players.Delete(id);
        }

        private PlayerDto Map(Player source)
        {
            return mapper.Map<PlayerDto>(source);
        }

        private Player Map(PlayerDto source)
        {
            return mapper.Map<Player>(source);
        }
    }
}