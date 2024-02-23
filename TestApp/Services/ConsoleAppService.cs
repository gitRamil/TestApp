using TestApp.Abstractions;
using TestApp.Exceptions;

namespace TestApp.Services;

public class ConsoleAppService(ICommandService commandService) : IAppService
{
    public void Run()
    {
        var exit = false;

        while (!exit)
        {
            Console.WriteLine($"Введите команду ({string.Join(", ", commandService.CommandNames)}):");
            var command = Console.ReadLine();

            try
            {
                commandService.GetCommand(command)
                              .RunCommand();
            }
            catch (ApplicationExitException)
            {
                exit = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
