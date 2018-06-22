using AutoMapper;
using Infrastructure.Pagination;
using Tournaments.Data.Entities;
using Tournaments.Dtos.Player;

namespace Tournaments.Domain.MapperProfiles
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            MapPagedList();
            MapEntity();
        }

        private void MapPagedList()
        {
            CreateMap<PagedList<Player>, PagedList<PlayerDto>>();
            CreateMap<PagedList<PlayerDto>, PagedList<Player>>();
        }

        private void MapEntity()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(
                    src => src.Position.Name));
            CreateMap<PlayerDto, Player>();

            CreateMap<PlayerForCreateDto, Player>();
            CreateMap<PlayerForUpdateDto, Player>()
                .ForMember(dest => dest.PositionId, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.Ignore());
            CreateMap<Player, PlayerForUpdateDto>();
        }
    }
}