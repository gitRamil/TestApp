using TestApp.Abstractions;
using TestApp.Commands;

namespace TestApp.Services;

public class CommandService(ITransSingleton transSingleton, IConsoleWorker consoleWorker) : ICommandService
{
    private readonly Dictionary<string, ICommand> _commands = new()
    {
        {
            "add", new AddCommand(transSingleton, consoleWorker)
        },
        {
            "get", new GetCommand(transSingleton, consoleWorker)
        },
        {
            "exit", new ExitCommand()
        }
    };

    public ICommand GetCommand(string? commandName)
    {
        if (commandName == null || !_commands.TryGetValue(commandName, out var command))
        {
            throw new ArgumentException($"Транзакия по имени {commandName} не найдена", nameof(commandName));
        }

        return command;
    }
}
