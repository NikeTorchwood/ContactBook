using ConsoleApp2.Domain;

namespace ConsoleApp2.Infrastructure.Context;

public interface IContextManager
{
    public List<Contact> LoadContactsFromFile();
    public void SaveContactsToFile(List<Contact> contacts);
}