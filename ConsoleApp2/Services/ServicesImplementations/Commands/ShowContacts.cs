using ConsoleApp2.Services.RepositoriesAbstractions;
using ConsoleApp2.Services.ServicesAbstractions;

namespace ConsoleApp2.Services.ServicesImplementations.Commands;

public class ShowContacts(IContactService service) : IAppCommand
{
    public string GetCommandTitle() => "Показать все контакты";


    public void Invoke()
    {
        service.ShowContacts();
    }
}