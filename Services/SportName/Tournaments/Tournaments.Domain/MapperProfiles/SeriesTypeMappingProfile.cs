using AutoMapper;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.Enum;

namespace Tournaments.Domain.MapperProfiles
{
    public class SeriesTypeMappingProfile : Profile
    {
        public SeriesTypeMappingProfile()
        {
            MapEntity();
        }

        private void MapEntity()
        {
            CreateMap<SeriesTypeEnum, SeriesType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(
                    src => src.ToString()));
        }
    }
}