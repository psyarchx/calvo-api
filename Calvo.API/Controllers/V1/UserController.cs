using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calvo.API.Controllers.Base;
using Calvo.Application.DTO.Request;
using Calvo.Application.DTO.Request.Create.General;
using Calvo.Application.DTO.Request.Update.General;
using Calvo.Application.DTO.Response.Common;
using Calvo.Application.Interfaces.Services.General;
using System.Net;

namespace Calvo.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : ControllerCustomBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService userService,
            ILogger<UserController> logger
        )
        {
            _userService = userService;
            _logger = logger;
        }

        //[HttpGet]
        //[Authorize(Roles = "Administrator")]
        //[Route("list")]
        //public IActionResult GetAll()
        //{
        //    var response = _userService.GetAllUsers();
        //    return ResponseCustom(response);
        //}

        //[HttpGet]
        //[Authorize(Roles = "Member,Administrator")]
        //[Route("{id}")]
        //public IActionResult Get(long id)
        //{
        //    return ResponseCustom(_userService.GetUserById(id));
        //}

        //[HttpPatch]
        //[Authorize(Roles = "Member,Administrator")]
        //public IActionResult Patch([FromBody] UserUpdateDtoRequest model)
        //{
        //    return ResponseCustom(_userService.UpdateUser(model));
        //}

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserCreateDtoRequest model)
        {
            return ResponseCustom(_userService.SaveUser(model));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateDtoRequest user)
        {
            return ResponseCustom(_userService.Authenticate(user));
        }
    }
}
