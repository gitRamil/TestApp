using TestApp.Entities;

namespace TestApp.Abstractions;

public interface ITransSingleton
{
    public Transaction GetSingleton();
}
