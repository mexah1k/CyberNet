using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournaments.Domain.Contracts;

namespace Dota2.ProCircuit.Api.Controllers
{
    [Route("api/seriestypes")]
    public class SeriesTypesController : Controller
    {
        private readonly ISeriesTypeService seriesTypes;

        public SeriesTypesController(ISeriesTypeService seriesTypesService)
        {
            seriesTypes = seriesTypesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await seriesTypes.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get(PagingParameter paging)
        {
            return Ok(await seriesTypes.Get(paging));
        }
    }
}