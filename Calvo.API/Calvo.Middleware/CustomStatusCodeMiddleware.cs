using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Calvo.Middleware{

public class CustomStatusCodeMiddleware
{
        private readonly RequestDelegate _next;

        public CustomStatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await _next(httpContext);

            if (httpContext.Response.StatusCode == 400)
            {
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("wrong login or password");
            }
            if (httpContext.Response.StatusCode == 200)
            {
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 200;
                await httpContext.Response.WriteAsync("success");
            }
        }
    }
}