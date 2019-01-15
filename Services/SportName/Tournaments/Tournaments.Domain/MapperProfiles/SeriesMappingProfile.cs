using AutoMapper;
using Infrastructure.Pagination;
using Tournaments.Data.Entities;
using Tournaments.Dtos.Series;

namespace Tournaments.Domain.MapperProfiles
{
    public class SeriesMappingProfile : Profile
    {
        public SeriesMappingProfile()
        {
            MapPagedList();
            MapEntity();
        }

        private void MapPagedList()
        {
            CreateMap<PagedList<Series>, PagedList<SeriesDto>>();
            CreateMap<PagedList<SeriesDto>, PagedList<Series>>();
        }

        private void MapEntity()
        {
            CreateMap<Series, SeriesDto>();
            CreateMap<SeriesDto, Series>();

            CreateMap<SeriesForCreateDto, Series>();
            CreateMap<SeriesForUpdateDto, Series>();
            CreateMap<Series, SeriesForUpdateDto>()
                .ForMember(dest => dest.TournamentId, opt => opt.Ignore());
        }
    }
}