using MovieStore.BackgroundServices;
using MovieStore.Models.Configurations;

namespace MovieStore.ServiceExtensions;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        return services.Configure<MongoDbConfiguration>(configuration.GetSection(nameof(MongoDbConfiguration)));
    }
    
    public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
    {
        services.AddHostedService<TestBackgroundService>();
        services.AddHostedService<TestHostedService>();

        return services;
    }
}