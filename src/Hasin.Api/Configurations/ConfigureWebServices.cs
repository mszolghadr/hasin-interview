using Microsoft.Extensions.DependencyInjection;

namespace Hasin.Api.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup).Assembly);

            return services;
        }
    }
}