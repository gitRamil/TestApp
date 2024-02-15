using Microsoft.Extensions.DependencyInjection;
using TestApp.Abstractions;
using TestApp.Extensions.IoC;

try
{
    var serviceCollection = new ServiceCollection();
    serviceCollection.AddApplicationServices();
    var serviceProvider = serviceCollection.BuildServiceProvider();
    var service = serviceProvider.GetService<IAppService>();

    service?.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Приложение неожиданно прекратило работу: {ex.Message}.");
}


