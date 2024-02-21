using TestApp.Abstractions;
using TestApp.Entities;

namespace TestApp.Services;

public class TransactionService : ITransSingleton
{
    private readonly Transaction _transaction = new();

    public Transaction GetSingleton() => _transaction;
}
