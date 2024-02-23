using Microsoft.Extensions.DependencyInjection;
using TestApp.Abstractions;
using TestApp.Services;

namespace TestApp.Extensions.IoC;

public static class ServiceProviderExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient<IAppService, ConsoleAppService>();
        services.AddTransient<ICommandService, CommandService>();
        services.AddTransient<IConsoleWorker, ConsoleWorkerService>();
        services.AddSingleton<ITransSingleton, TransactionService>();

        return services;
    }
}
