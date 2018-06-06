using AutoMapper;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Entities;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Position;

namespace Tournaments.Domain.Services
{
    public class PositionService : IPositionService
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;

        public PositionService(IDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PositionDto> Get(int id)
        {
            var position = await context.Positions.GetOrThrow(id);
            return Map(position);
        }

        public async Task<PagedList<PositionDto>> Get(PagingParameter paging)
        {
            var positions = await context.Positions.ToPaginatedResult(paging);
            return Map(positions);
        }

        private PositionDto Map(Position source)
        {
            return mapper.Map<PositionDto>(source);
        }

        private PagedList<PositionDto> Map(PagedList<Position> source)
        {
            return mapper.Map<PagedList<PositionDto>>(source);
        }
    }
}