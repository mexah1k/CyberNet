using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Series;

namespace Tournament.Api.Controllers
{
    [Route("api/series")]
    public class SeriesController : Controller
    {
        private readonly ISeriesService series;

        public SeriesController(ISeriesService seriesService)
        {
            series = seriesService;
        }

        [HttpGet("{id}", Name = "GetSeries")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await series.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get(PagingParameter paging)
        {
            return Ok(await series.Get(paging));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeriesForCreateDto seriesForCreationDto)
        {
            var createdSeries = await series.Create(seriesForCreationDto);
            return CreatedAtRoute("GetSeries", new { id = createdSeries.Id }, createdSeries);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await series.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SeriesForUpdateDto seriesDto, int id)
        {
            await series.Update(seriesDto, id);
            return Ok();
        }
    }
}