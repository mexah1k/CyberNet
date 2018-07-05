using AutoMapper;
using Infrastructure.Pagination;
using Tournaments.Data.Entities;
using Tournaments.Dtos.Tournament;

namespace Tournaments.Domain.MapperProfiles
{
    public class TournamentMappingProfile : Profile
    {
        public TournamentMappingProfile()
        {
            MapPagedList();
            MapEntity();
        }

        private void MapPagedList()
        {
            CreateMap<PagedList<Tournament>, PagedList<TournamentDto>>();
            CreateMap<PagedList<TournamentDto>, PagedList<Tournament>>();
        }

        private void MapEntity()
        {
            CreateMap<Tournament, TournamentDto>();
            CreateMap<TournamentDto, Tournament>();

            CreateMap<TournamentForCreateDto, Tournament>();
            CreateMap<TournamentForUpdateDto, Tournament>();
            CreateMap<Tournament, TournamentForUpdateDto>();
        }
    }
}