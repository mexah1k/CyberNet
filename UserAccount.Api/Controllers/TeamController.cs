using AutoMapper;
using Database.Abstractions.Repositories.UnitOfWork;
using Database.Entities.Entities;
using Mapper.Dtos.UserAccount;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccount.Api.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TeamController(IUnitOfWork unitOfWork, IMapper mapper)
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