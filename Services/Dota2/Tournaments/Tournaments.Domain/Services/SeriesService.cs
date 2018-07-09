using AutoMapper;
using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;
using Tournaments.Data.Entities;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Series;

namespace Tournaments.Domain.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SeriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<SeriesDto> Get(int id)
        {
            var series = await unitOfWork.Series.Get(id);
            return Map(series);
        }

        public async Task<PagedList<SeriesDto>> Get(PagingParameter paging)
        {
            var series = await unitOfWork.Series.Get(paging);
            return Map(series);
        }

        public async Task<SeriesDto> Create(SeriesForCreateDto seriesDto)
        {
            var series = Map(seriesDto);

            await unitOfWork.Series.Create(series);

            await SaveDbChangesAsync();

            return Map(series);
        }

        public async Task Delete(int id)
        {
            await unitOfWork.Series.Delete(id);
            await SaveDbChangesAsync();
        }

        public async Task Update(SeriesForUpdateDto seriesForUpdateDto, int id)
        {
            var series = await unitOfWork.Series.Get(id);
            series.Tournament = await unitOfWork.Tournament.Get(seriesForUpdateDto.TournamentId);

            await SaveDbChangesAsync();
        }

        private async Task SaveDbChangesAsync()
        {
            if (!await unitOfWork.SaveChangesAsync())
                throw new Exception("Something went wrong."); // todo: move message to resource file
        }

        private SeriesDto Map(Series source)
        {
            return mapper.Map<SeriesDto>(source);
        }

        private Series Map(SeriesForCreateDto source)
        {
            return mapper.Map<Series>(source);
        }

        private PagedList<SeriesDto> Map(PagedList<Series> source)
        {
            return mapper.Map<PagedList<SeriesDto>>(source);
        }
    }
}