using AutoMapper;
using Data.Entities.Team;
using Data.Entities.Team.Enum;
using Dtos.Team;

namespace Mapper.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(
                    src => src.Position.Name));
            CreateMap<PlayerDto, Player>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();

            CreateMap<Team, TeamForCreationDto>();
            CreateMap<TeamForCreationDto, Team>();

            CreateMap<Player, PlayerForCreationDto>();
            CreateMap<PlayerForCreationDto, Player>();

            CreateMap<Player, PlayerForUpdateDto>();
            CreateMap<PlayerForUpdateDto, Player>();

            CreateMap<PositionEnum, Position>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));
        }
    }
}