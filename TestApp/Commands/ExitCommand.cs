using TestApp.Abstractions;
using TestApp.Exceptions;

namespace TestApp.Commands;

public class ExitCommand : ICommand
{
    public void RunCommand()
    {
        Exit();
    }

    private static void Exit()
    {
        throw new ApplicationExitException();
    }
}
