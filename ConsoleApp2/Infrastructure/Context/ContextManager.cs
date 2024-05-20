using ConsoleApp2.Domain;
using Newtonsoft.Json;

namespace ConsoleApp2.Infrastructure.Context;

public class ContextManager(string path) : IContextManager
{
    public List<Contact> LoadContactsFromFile()
    {
        if (!File.Exists(path))
        {
            return [];
        }
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Contact>>(json);
    }

    public void SaveContactsToFile(List<Contact> contacts)
    {
        var json = JsonConvert.SerializeObject(contacts);
        File.WriteAllTextAsync(path, json);
    }
}