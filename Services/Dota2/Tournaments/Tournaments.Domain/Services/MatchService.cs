using AutoMapper;
using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;
using Tournaments.Data.Entities;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Match;

namespace Tournaments.Domain.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MatchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<MatchDto> Get(int id)
        {
            var match = await unitOfWork.Matches.Get(id);
            return Map(match);
        }

        public async Task<PagedList<MatchDto>> Get(PagingParameter paging)
        {
            var matches = await unitOfWork.Matches.Get(paging);
            return Map(matches);
        }

        public async Task<MatchDto> Create(MatchForCreateDto matchDto)
        {
            var match = Map(matchDto);

            await unitOfWork.Matches.Create(match);
            await SaveDbChangesAsync();

            return Map(match);
        }

        public async Task Delete(int id)
        {
            await unitOfWork.Matches.Delete(id);
            await SaveDbChangesAsync();
        }

        public async Task Update(MatchForUpdateDto matchForUpdateDto, int id)
        {
            var match = await unitOfWork.Matches.Get(id);

            mapper.Map(matchForUpdateDto, match);
            await SaveDbChangesAsync();
        }

        private async Task SaveDbChangesAsync()
        {
            if (!await unitOfWork.SaveChangesAsync())
                throw new Exception("Something went wrong."); // todo: move message to resource file
        }

        private MatchDto Map(Match source)
        {
            return mapper.Map<MatchDto>(source);
        }

        private PagedList<MatchDto> Map(PagedList<Match> source)
        {
            return mapper.Map<PagedList<MatchDto>>(source);
        }

        private Match Map(MatchForCreateDto source)
        {
            return mapper.Map<Match>(source);
        }
    }
}