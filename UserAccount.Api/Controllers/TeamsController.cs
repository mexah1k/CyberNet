using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Abstractions.Repositories.UnitOfWork;
using Mapper.Dtos.Team;
using Microsoft.AspNetCore.Mvc;

namespace Team.Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<TeamDto> Get(int id)
        {
            var team = await unitOfWork.Teams.Get(id);

            return Map(team);
        }

        // GET api/team
        [HttpGet]
        public async Task<IEnumerable<TeamDto>> Get()
        {
            var teams = await unitOfWork.Teams.Get();

            return teams.Select(Map);
        }

        private TeamDto Map(Database.Entities.Entities.Team source)
        {
            return mapper.Map<TeamDto>(source);
        }

        private Database.Entities.Entities.Team Map(TeamDto source)
        {
            return mapper.Map<Database.Entities.Entities.Team>(source);
        }
    }
}