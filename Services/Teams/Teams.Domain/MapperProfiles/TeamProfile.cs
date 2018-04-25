using AutoMapper;
using Infrastructure.Pagination;
using Teams.Data.Entities;
using Teams.Data.Entities.Enum;
using Teams.Dtos;

namespace Teams.Domain.MapperProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            MapEntities();
            MapPagedLists();
        }

        private void MapEntities()
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

            CreateMap<PositionEnum, Position>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));
        }

        private void MapPagedLists()
        {
            CreateMap<PagedList<Player>, PagedList<PlayerDto>>();
            CreateMap<PagedList<PlayerDto>, PagedList<Player>>();
        }
    }
}