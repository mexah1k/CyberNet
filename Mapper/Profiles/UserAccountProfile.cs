using AutoMapper;
using Database.Entities.Entities;
using Mapper.Dtos.UserAccount;

namespace Mapper.Profiles
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();
        }
    }
}