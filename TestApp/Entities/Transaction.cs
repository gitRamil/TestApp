using Newtonsoft.Json;

namespace TestApp.Entities;

public class Transaction
{
    private readonly Dictionary<int, Transaction> _transactions = new();

    public Transaction()
    {
    }

    private Transaction(int id, decimal amount, DateTime date)
    {
        Id = id;
        Amount = amount;
        TransactionDate = date;
    }

    [JsonProperty(Order = 3)]
    private decimal Amount { get; }

    [JsonProperty(Order = 1)]
    private int Id { get; }

    [JsonProperty(Order = 2)]
    private DateTime TransactionDate { get; }

    public void AddTransaction(int id, DateTime date, decimal amount)
    {
        if (_transactions.ContainsKey(id))
        {
            throw new ArgumentException($"Транзакция с идентификатором {id} уже существует.", nameof(id));
        }

        _transactions.Add(id, new Transaction(id, amount, date));
    }

    public string GetTransaction(int id)
    {
        if (!IsTransactionExist(id))
        {
            throw new ArgumentNullException(nameof(id), $"Транзакия по идентификатору {id} не найдена");
        }

        return JsonConvert.SerializeObject(_transactions[id]);
    }

    public bool IsTransactionExist(int id) => _transactions.TryGetValue(id, out _);
}
