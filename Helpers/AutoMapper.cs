using AutoMapper;
using SurfLog.Api.Dtos;
using SurfLog.Api.Models;

namespace SurfLog.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Session, SessionDto>();
            CreateMap<SessionDto, Session>();
        }
    }
}