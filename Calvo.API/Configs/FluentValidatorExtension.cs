using Microsoft.Extensions.DependencyInjection;

namespace Calvo.API.Configs
{
    public static class FluentValidatorExtension
    {
        public static void ConfigureFluentValidations(this IServiceCollection services)
        {
            //services.AddScoped<IValidator<AuthenticateDtoRequest>, AuthenticateValidator>();
        }
    }
}
