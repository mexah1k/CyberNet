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
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlayersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET api/useraccount/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await unitOfWork.Players.Get(id);

            if (user == null) return NotFound();

            return Ok(Map(user));
        }

        // GET api/useraccount
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await unitOfWork.Players.Get();

            if (users == null) return NotFound();

            return Ok(users.Select(Map));
        }

        // POST api/useraccount
        [HttpPost]
        public async Task Post([FromBody]PlayerDto player)
        {
            await unitOfWork.Players.Add(Map(player));
        }

        // DELETE api/useraccount/5
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