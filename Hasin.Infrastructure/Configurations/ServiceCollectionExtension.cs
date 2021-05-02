using Microsoft.Extensions.DependencyInjection;

namespace Hasin.Infrastructure.Configurations
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}