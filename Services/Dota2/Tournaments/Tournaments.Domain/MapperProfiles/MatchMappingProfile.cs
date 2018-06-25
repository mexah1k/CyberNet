using AutoMapper;
using Infrastructure.Pagination;
using Tournaments.Data.Entities;
using Tournaments.Dtos.Match;

namespace Tournaments.Domain.MapperProfiles
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            MapPagedList();
            MapEntity();
        }

        private void MapPagedList()
        {
            CreateMap<PagedList<Match>, PagedList<MatchDto>>();
            CreateMap<PagedList<MatchDto>, PagedList<Match>>();
        }

        private void MapEntity()
        {
            CreateMap<Match, MatchDto>();
            CreateMap<MatchDto, Match>();

            CreateMap<MatchForCreateDto, Match>();
            CreateMap<MatchForUpdateDto, Match>()
                .ForMember(dest => dest.SeriesId, opt => opt.Ignore())
                .ForMember(dest => dest.DireTeamId, opt => opt.Ignore())
                .ForMember(dest => dest.RadiantTeamId, opt => opt.Ignore());
        }
    }
}