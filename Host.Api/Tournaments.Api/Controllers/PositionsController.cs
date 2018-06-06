using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Domain.Contracts;

namespace Dota2.ProCircuit.Api.Controllers
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
        public async Task<IActionResult> Get(PagingParameter paging)
        {
            return Ok(await positions.Get(paging));
        }

    }
}