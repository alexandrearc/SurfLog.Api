using AutoMapper;
using SurfLog.Api.Dtos;
using SurfLog.Api.Models;
using SurfLog.Api.Requests;

namespace SurfLog.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<RegisterRequest, User>(); 
            CreateMap<PostSessionRequest, Session>();
        }
    }
}