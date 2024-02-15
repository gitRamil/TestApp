namespace TestApp.Helpers;

public static class ConsoleHelper
{
    public static T ReadValue<T>(string message, Func<string, T> parser)
    {
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine() ?? string.Empty;

            try
            {
                var value = parser.Invoke(input);
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Некорректный ввод: {ex.Message}. Попробуйте еще раз.");
            }
        }
    }
}
