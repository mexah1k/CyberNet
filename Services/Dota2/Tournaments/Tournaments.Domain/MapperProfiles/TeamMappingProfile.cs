using AutoMapper;
using Infrastructure.Pagination;
using System.Linq;
using Tournaments.Data.Entities;
using Tournaments.Dtos.Team;

namespace Tournaments.Domain.MapperProfiles
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            MapEntities();
            MapPagedLists();
        }

        private void MapEntities()
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

        private void MapPagedLists()
        {
            CreateMap<PagedList<Team>, PagedList<TeamDto>>()
                .ForMember(dest => dest.Result, opt => opt.MapFrom(
                    src => src.Result.OrderByDescending(t => t.GetPoints())));
            CreateMap<PagedList<TeamDto>, PagedList<Team>>();
        }
    }
}