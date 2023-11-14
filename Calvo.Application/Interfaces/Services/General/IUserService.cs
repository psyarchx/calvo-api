using Calvo.Application.DTO.Request;
using Calvo.Application.DTO.Request.Create.General;
using Calvo.Application.DTO.Request.Update.General;
using Calvo.Application.DTO.Response.General;
using Calvo.Application.DTO.Response.Common;

namespace Calvo.Application.Interfaces.Services.General
{
    public interface IUserService
    {
        DefaultDtoResponse<AuthenticateDtoResponse> Authenticate(AuthenticateDtoRequest user);
        DefaultDtoResponse<UserGetDtoResponse> SaveUser(UserCreateDtoRequest model);
        DefaultDtoResponse<ICollection<UserGetDtoResponse>> GetAllUsers();
        DefaultDtoResponse<UserGetDtoResponse> GetUserById(long id);
        DefaultDtoResponse<UserGetDtoResponse> UpdateUser(UserUpdateDtoRequest model);
    }
}
