using TestApp.Dtos;

namespace TestApp.Abstractions;

public interface IConsoleWorker
{
    public TransactionDto GetTransaction();

    public int GetTransactionId();

    public void TransactionAddedSuccessfully();
}
