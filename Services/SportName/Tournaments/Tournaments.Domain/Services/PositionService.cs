using AutoMapper;
using Infrastructure.Pagination;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;
using Tournaments.Data.Entities;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Position;

namespace Tournaments.Domain.Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PositionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PositionDto> Get(int id)
        {
            var position = await unitOfWork.Position.Get(id);
            return Map(position);
        }

        public async Task<PagedList<PositionDto>> Get(PagingParameter paging, PositionFilter filter)
        {
            var positions = await unitOfWork.Position.Get(paging, filter);
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