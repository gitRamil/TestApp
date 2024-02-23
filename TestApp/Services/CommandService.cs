using TestApp.Abstractions;
using TestApp.Commands;

namespace TestApp.Services;

public class CommandService : ICommandService
{
    private readonly Dictionary<string, ICommand> _commands;

    public CommandService(ITransSingleton transSingleton, IConsoleWorker consoleWorker) =>
        _commands = new Dictionary<string, ICommand>
        {
            {
                ((List<string>)CommandNames)[0], new AddCommand(transSingleton, consoleWorker)
            },
            {
                ((List<string>)CommandNames)[1], new GetCommand(transSingleton, consoleWorker)
            },
            {
                ((List<string>)CommandNames)[2], new ExitCommand()
            }
        };

    public IReadOnlyCollection<string> CommandNames { get; } = new List<string>
    {
        "add",
        "get",
        "exit"
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
