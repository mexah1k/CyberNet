using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Match;

namespace Dota2.ProCircuit.Api.Controllers
{
    [Route("api/matches")]
    public class MatchesController : Controller
    {
        private readonly IMatchService matches;

        public MatchesController(IMatchService matchService)
        {
            matches = matchService;
        }

        [HttpGet("{id}", Name = "GetMatch")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await matches.Get(id));
        }

        [HttpGet(Name = "GetMatches")]
        public async Task<IActionResult> Get(PagingParameter paging)
        {
            return Ok(await matches.Get(paging));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatchForCreateDto matchDto)
        {
            var createdMatch = await matches.Create(matchDto);
            return CreatedAtRoute("GetMatch", new { id = createdMatch.Id }, createdMatch);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await matches.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] MatchForUpdateDto matchDto, int id)
        {
            await matches.Update(matchDto, id);
            return Ok();
        }
    }
}