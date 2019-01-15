using AutoMapper;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Entities;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.SeriesType;

namespace Tournaments.Domain.Services
{
    public class SeriesTypeService : ISeriesTypeService
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;

        public SeriesTypeService(IDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SeriesTypeDto> Get(int id)
        {
            var seriesType = await context.SeriesTypes.GetOrThrow(id);
            return Map(seriesType);
        }

        public async Task<PagedList<SeriesTypeDto>> Get(PagingParameter paging)
        {
            var seriesTypes = await context.SeriesTypes.ToPaginatedResult(paging);
            return Map(seriesTypes);
        }

        private SeriesTypeDto Map(SeriesType source)
        {
            return mapper.Map<SeriesTypeDto>(source);
        }

        private PagedList<SeriesTypeDto> Map(PagedList<SeriesType> source)
        {
            return mapper.Map<PagedList<SeriesTypeDto>>(source);
        }
    }
}