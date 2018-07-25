using AutoMapper;
using Infrastructure.Pagination;
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
                    src => src.Points));
            CreateMap<TeamDto, Team>();

            CreateMap<TeamForCreateDto, Team>();
            CreateMap<TeamForUpdateDto, Team>();
            CreateMap<Team, TeamForUpdateDto>();
            CreateMap<TeamForUpdateDto, TeamForCreateDto>();
        }

        private void MapPagedLists()
        {
            CreateMap<PagedList<Team>, PagedList<TeamDto>>();
            CreateMap<PagedList<TeamDto>, PagedList<Team>>();
        }
    }
}