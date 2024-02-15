using Microsoft.Extensions.DependencyInjection;
using TestApp.Abstractions;
using TestApp.Services;

namespace TestApp.Extensions.IoC;

public static class ServiceProviderExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient<IAppService, AppService>();

        return services;
    }
}
