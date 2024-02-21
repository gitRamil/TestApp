using TestApp.Dtos;

namespace TestApp;

public interface IConsoleWorker
{
    public TransactionDto GetTransaction();

    public int GetTransactionId();

    public void TransactionAddedSuccessfully();
}
