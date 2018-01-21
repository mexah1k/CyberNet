using AutoMapper;
using Database.Entities.Entities;
using Mapper.Dtos.Team;

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
        }
    }
}