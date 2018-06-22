using AutoMapper;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.Enum;

namespace Tournaments.Domain.MapperProfiles
{
    public class PositionMappingProfile : Profile
    {
        public PositionMappingProfile()
        {
            MapEntity();
        }

        private void MapEntity()
        {
            CreateMap<PositionEnum, Position>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(
                    src => src.ToString()));
        }
    }
}