using AutoMapper;
using Calvo.Application.DTO.Request.Create.General;
using Calvo.Application.DTO.Request.Update.General;
using Calvo.Application.DTO.Response.General;
using Calvo.Domain.Entities.General;

namespace Calvo.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDtoResponse>().ReverseMap();
            CreateMap<User, UserCreateDtoRequest>().ReverseMap();
            CreateMap<User, UserUpdateDtoRequest>().ReverseMap();
        }
    }
}
