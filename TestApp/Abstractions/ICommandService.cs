namespace TestApp.Abstractions;

public interface ICommandService
{
    public ICommand GetCommand(string? commandName);
}
