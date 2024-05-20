using ConsoleApp2.Services.RepositoriesAbstractions;
using ConsoleApp2.Services.ServicesAbstractions;
using ConsoleApp2.Services.ServicesContracts;

namespace ConsoleApp2.Services.ServicesImplementations.Commands;

public class UpdateContact(IContactService service) : IAppCommand
{
    public string GetCommandTitle() => "Изменить контакт";

    public void Invoke()
    {
        service.ShowContacts();
        service.UpdateContact();
        service.ShowContacts();
    }
}