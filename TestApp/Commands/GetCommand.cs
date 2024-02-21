using TestApp.Abstractions;

namespace TestApp.Commands;

public class GetCommand(ITransSingleton transaction, IConsoleWorker consoleWorker) : ICommand
{
    public void RunCommand()
    {
        GetTransaction();
    }

    private void GetTransaction()
    {
        var id = consoleWorker.GetTransactionId();

        var jsonTransaction = transaction.GetSingleton()
                                         .GetTransaction(id);

        Console.WriteLine(jsonTransaction);
    }
}
