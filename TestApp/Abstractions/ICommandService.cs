namespace TestApp.Abstractions;

public interface ICommandService
{
    public IReadOnlyCollection<string> CommandNames { get; }

    public ICommand GetCommand(string? commandName);
}
