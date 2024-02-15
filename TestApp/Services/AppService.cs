using System.Globalization;
using TestApp.Abstractions;
using TestApp.Entities;
using TestApp.Helpers;

namespace TestApp.Services;

public class AppService : IAppService
{
    public void Run()
    {
        var transaction = new Transaction();
        var exit = false;

        while (!exit)
        {
            Console.WriteLine("Введите команду (add, get, exit):");
            var command = Console.ReadLine();

            try
            {
                switch (command?.ToLower())
                {
                    case "add":
                        AddTransaction(transaction);
                        break;

                    case "get":
                        GetTransaction(transaction);
                        break;

                    case "exit":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Некорректная команда, попробуйте еще раз");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void AddTransaction(Transaction transaction)
    {
        const string dateFormat = "dd.MM.yyyy";
        
        var id = ConsoleHelper.ReadValue("Введите Id:", int.Parse);

        while (transaction.IsTransactionExist(id))
        {
            Console.WriteLine($"Транзакция с идентификатором {id} уже существует");
            id = ConsoleHelper.ReadValue("Введите Id:", int.Parse);
        }
        
        var date = ConsoleHelper.ReadValue($"Введите дату (в формате {dateFormat}):", input => DateTime.ParseExact(input, dateFormat, CultureInfo.InvariantCulture));
        var amount = ConsoleHelper.ReadValue("Введите сумму:", decimal.Parse);

        transaction.AddTransaction(id, date, amount);
        Console.WriteLine("Транзакция была успешно добавлена");
    }

    private static void GetTransaction(Transaction transaction)
    {
        var id = ConsoleHelper.ReadValue("Введите Id:", int.Parse);

        var jsonTransaction = transaction.GetTransaction(id);

        Console.WriteLine(jsonTransaction);
    }
}
