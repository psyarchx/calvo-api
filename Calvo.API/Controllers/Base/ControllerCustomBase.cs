using Microsoft.AspNetCore.Mvc;
using Calvo.Application.DTO.Response.Common;

namespace Calvo.API.Controllers.Base
{
    public class ControllerCustomBase : ControllerBase
    {
        protected IActionResult ResponseCustom<T>(DefaultDtoResponse<T> response)
        {
            if (response != null && response.Success)
                return StatusCode(response.StatusCode, response.Result);
            else if (response != null && !response.Success)
                return StatusCode(response.StatusCode, response.Errors != null ? new { response.Errors } : response.Errors);

            return StatusCode(500);
        }
    }
}
