using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Domain.Contracts;

namespace Tournament.Api.Controllers
{
    [Route("api/positions")]
    public class PositionsController : Controller
    {
        private readonly IPositionService positions;

        public PositionsController(IPositionService positions)
        {
            this.positions = positions;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await positions.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get(PagingParameter paging, PositionFilter filter)
        {
            return Ok(await positions.Get(paging, filter));
        }
    }
}