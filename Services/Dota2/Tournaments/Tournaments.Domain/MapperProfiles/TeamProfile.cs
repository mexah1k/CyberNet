using AutoMapper;
using Infrastructure.Pagination;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.Enum;
using Tournaments.Dtos;

namespace Tournaments.Domain.MapperProfiles
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
            MapTeam();
            MapPlayer();
            MapPosition();
        }

        private void MapPosition()
        {
            CreateMap<PositionEnum, Position>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(
                    src => src.ToString()));
        }

        private void MapTeam()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.Points, opt => opt.MapFrom(
                    src => src.GetPoints()));
            CreateMap<TeamDto, Team>();

            CreateMap<TeamForCreationDto, Team>();
            CreateMap<TeamForUpdateDto, Team>();
            CreateMap<Team, TeamForUpdateDto>();
            CreateMap<TeamForUpdateDto, TeamForCreationDto>();
        }

        private void MapPlayer()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(
                    src => src.Position.Name));
            CreateMap<PlayerDto, Player>();

            CreateMap<PlayerForCreationDto, Player>();
            CreateMap<PlayerForUpdateDto, Player>()
                .ForMember(dest => dest.PositionId, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.Ignore());
            CreateMap<Player, PlayerForUpdateDto>();
        }

        private void MapPagedLists()
        {
            CreateMap<PagedList<Player>, PagedList<PlayerDto>>();
            CreateMap<PagedList<PlayerDto>, PagedList<Player>>();

            CreateMap<PagedList<Team>, PagedList<TeamDto>>();
            CreateMap<PagedList<TeamDto>, PagedList<Team>>();
        }
    }
}