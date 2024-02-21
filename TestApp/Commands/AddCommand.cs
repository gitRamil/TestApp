using TestApp.Abstractions;

namespace TestApp.Commands;

public class AddCommand(ITransSingleton transaction, IConsoleWorker consoleWorker) : ICommand
{
    public void RunCommand()
    {
        AddTransaction();
    }

    private void AddTransaction()
    {
        var newTransaction = consoleWorker.GetTransaction();

        transaction.GetSingleton()
                   .AddTransaction(newTransaction.Id, newTransaction.Date, newTransaction.Amount);

        consoleWorker.TransactionAddedSuccessfully();
    }
}
