using AutoMapper;
using UserApi.Data.Dto;
using UserApi.Models;

namespace UserApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
