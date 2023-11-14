using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Calvo.CrossCutting.Options;
using static Calvo.CrossCutting.Options.ExampleOptionRoot;

namespace Calvo.API.Configs
{
    public static class OptionExtension
    {
        public static void SetOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ExampleOption>(configuration.GetSection(ExampleOptionRoot.Section));
        }
    }
}
