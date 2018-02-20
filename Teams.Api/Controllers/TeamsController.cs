using AutoMapper;
using Data.Abstractions.Repositories.UnitOfWork;
using Data.Entities.Entities;
using Dtos.Team;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Api.Controllers
{
    [Route("api/teams")]
    public class TeamsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TeamsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetTeam")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await unitOfWork.Teams.Get(id);

            return Ok(Map(team));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await unitOfWork.Teams.Get();

            return Ok(teams.Select(Map));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamForCreationDto teamForCreationDto)
        {
            if (teamForCreationDto == null)
                return BadRequest();

            var team = Map(teamForCreationDto);
            await unitOfWork.Teams.Create(team);

            if (!await unitOfWork.SaveChangesAsync())
                return BadRequest();

            return CreatedAtRoute("GetTeam", new { id = team.Id }, Map(team));
        }

        private TeamDto Map(Team source)
        {
            return mapper.Map<TeamDto>(source);
        }

        private Team Map(TeamDto source)
        {
            return mapper.Map<Team>(source);
        }

        private Team Map(TeamForCreationDto source)
        {
            return mapper.Map<Team>(source);
        }
    }
}