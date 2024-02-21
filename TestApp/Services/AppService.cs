using TestApp.Abstractions;
using TestApp.Exceptions;

namespace TestApp.Services;

public class AppService(ICommandService commandService) : IAppService
{
    public void Run()
    {
        var exit = false;

        while (!exit)
        {
            Console.WriteLine("Введите команду (add, get, exit):");
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
