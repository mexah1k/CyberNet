using AutoMapper;
using Database.Abstractions.Repositories.UnitOfWork;
using Database.Entities.Entities;
using Mapper.Dtos.Team;
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

            if (team == null)
                return NotFound();

            return Ok(Map(team));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await unitOfWork.Teams.Get();

            if (teams == null) // todo:  || !teams.Any()
                return NotFound();

            return Ok(teams.Select(Map));
        }

        public async Task<IActionResult> Create([FromBody] TeamForCreationDto teamDto)
        {
            if (teamDto == null)
                return BadRequest();

            var team = Map(teamDto);
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