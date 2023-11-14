using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Calvo.Application.DTO.Request;
using Calvo.Application.DTO.Request.Create.General;
using Calvo.Application.DTO.Request.Update.General;
using Calvo.Application.DTO.Response.Common;
using Calvo.Application.DTO.Response.General;
using Calvo.Application.Interfaces.Services.General;
using Calvo.Domain.Entities.General;
using Calvo.Domain.Interfaces.Repositories.General;
using System.Data;
using System.Net;
using static Calvo.CrossCutting.Options.ExampleOptionRoot;

namespace Calvo.Application.Services.General
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly ExampleOption _exampleOptions;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<UserService> logger,
            IOptions<ExampleOption> exampleOptions
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _exampleOptions = exampleOptions.Value;
        }

        public DefaultDtoResponse<AuthenticateDtoResponse> Authenticate(AuthenticateDtoRequest request)
        {
            try
            {
                var userModel = new User() { Password = request.Password };

                var user = _userRepository.GetAllUsers()
                    .Where(x => x.Digest == userModel.Digest)
                    .Select(login => _mapper.Map<UserGetDtoResponse>(login))
                    .FirstOrDefault();

                if (user == null)
                    return new DefaultDtoResponse<AuthenticateDtoResponse>(HttpStatusCode.BadRequest, null);

                var response = new AuthenticateDtoResponse()
                {
                    Exists = true
                };

                return new DefaultDtoResponse<AuthenticateDtoResponse>(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return new DefaultDtoResponse<AuthenticateDtoResponse>(HttpStatusCode.InternalServerError, null);
            }
        }

        public DefaultDtoResponse<UserGetDtoResponse> SaveUser(UserCreateDtoRequest model)
        {
            try
            {
                if (UserAlreadyExists(model))
                {
                    _logger.LogInformation("User already exists.");

                    return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.BadRequest, null)
                        .AddErrorMessage("User already exists.");
                }

                var user = new User()
                {
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    CreationDate = DateTime.Now,
                    LastUpdated = DateTime.Now
                };

                user = _userRepository.CreateUser(user);

                var userMapped = _mapper.Map<UserGetDtoResponse>(user);

                _logger.LogInformation("User created.", userMapped);

                return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.OK, userMapped);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.InternalServerError, null);
            }
        }

        private bool UserAlreadyExists(UserCreateDtoRequest model)
        {
            return _userRepository
                .GetAllUsers()
                .Where(x => x.Name.ToLower() == model.Name.ToLower())
                .Where(x => x.Email.ToLower() == model.Email.ToLower())
                .Any();
        }

        public DefaultDtoResponse<ICollection<UserGetDtoResponse>> GetAllUsers()
        {
            try
            {
                var result = _userRepository.GetAllUsers()
                    .Select(user => _mapper.Map<UserGetDtoResponse>(user))
                    .ToList();

                if (result == default)
                {
                    _logger.LogInformation("No users were found.");
                    return new DefaultDtoResponse<ICollection<UserGetDtoResponse>>(HttpStatusCode.BadRequest, null);
                }

                _logger.LogInformation("Users found.", result);

                return new DefaultDtoResponse<ICollection<UserGetDtoResponse>>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return new DefaultDtoResponse<ICollection<UserGetDtoResponse>>(HttpStatusCode.InternalServerError, null);
            }
        }

        public DefaultDtoResponse<UserGetDtoResponse> GetUserById(long id)
        {
            try
            {
                var user = _userRepository.GetUserById(id);
                var result = _mapper.Map<UserGetDtoResponse>(user);

                if (result == default)
                {
                    _logger.LogInformation("No users were found.");
                    return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.BadRequest, null);
                }

                _logger.LogInformation("User found.", result);

                return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.InternalServerError, null);
            }
        }

        public DefaultDtoResponse<UserGetDtoResponse> UpdateUser(UserUpdateDtoRequest model)
        {
            try
            {
                var current = _userRepository.GetUserById(model.Id);

                if (current == null)
                {
                    _logger.LogError("User was not found.");
                    return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.BadRequest, null);
                }

                var user = new User()
                {
                    Id = model.Id,
                    Email = model.Email,
                    LastUpdated = DateTime.Now
                };

                user = _userRepository.UpdateUser(user);
                var result = _mapper.Map<UserGetDtoResponse>(user);

                _logger.LogInformation("User updated successfully.", result);

                return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return new DefaultDtoResponse<UserGetDtoResponse>(HttpStatusCode.InternalServerError, null);
            }
        }
    }
}
