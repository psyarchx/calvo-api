using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Calvo.Application.Interfaces.Services.General;
using Calvo.Application.Services.General;
using Calvo.Domain.Interfaces.Repositories.General;
using Calvo.Infrastructure.Data.Repositories.General;

namespace Calvo.API.Configs
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            SetServices(services);
            SetRepositories(services);
            SetSingletons(services);
        }

        private static void SetServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void SetRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void SetSingletons(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
