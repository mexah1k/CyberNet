using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Abstractions.Repositories.UnitOfWork;
using Database.Entities.Entities;
using Mapper.Dtos.Team;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/team/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await unitOfWork.Teams.Get(id);

            if (team == null) return NotFound();

            return Ok(Map(team));
        }

        // GET api/team
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await unitOfWork.Teams.Get();

            if (teams == null) return NotFound();

            return Ok(teams.Select(Map));
        }

        private TeamDto Map(Team source)
        {
            return mapper.Map<TeamDto>(source);
        }

        private Team Map(TeamDto source)
        {
            return mapper.Map<Team>(source);
        }
    }
}