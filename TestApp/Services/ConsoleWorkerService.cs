using System.Globalization;
using TestApp.Abstractions;
using TestApp.Dtos;
using TestApp.Helpers;

namespace TestApp.Services;

public class ConsoleWorkerService(ITransSingleton transaction) : IConsoleWorker
{
    public TransactionDto GetTransaction()
    {
        const string dateFormat = "dd.MM.yyyy";
        var id = ConsoleHelper.ReadValue("Введите Id:", int.Parse);

        while (transaction.GetSingleton()
                          .IsTransactionExist(id))
        {
            Console.WriteLine($"Транзакция с идентификатором {id} уже существует");
            id = ConsoleHelper.ReadValue("Введите Id:", int.Parse);
        }

        var date = ConsoleHelper.ReadValue($"Введите дату (в формате {dateFormat}):", input => DateTime.ParseExact(input, dateFormat, CultureInfo.InvariantCulture));
        var amount = ConsoleHelper.ReadValue("Введите сумму:", decimal.Parse);

        return new TransactionDto(id, date, amount);
    }

    public int GetTransactionId() => ConsoleHelper.ReadValue("Введите Id:", int.Parse);

    public void TransactionAddedSuccessfully() => Console.WriteLine("Транзакция была успешно добавлена");
}
