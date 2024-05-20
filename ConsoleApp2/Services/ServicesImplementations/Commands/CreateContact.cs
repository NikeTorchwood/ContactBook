using ConsoleApp2.Services.RepositoriesAbstractions;
using ConsoleApp2.Services.ServicesAbstractions;
using ConsoleApp2.Services.ServicesContracts;

namespace ConsoleApp2.Services.ServicesImplementations.Commands;

public class CreateContact(IContactService service) : IAppCommand
{
    public string GetCommandTitle() => "Создать контакт";

    public void Invoke()
    {
        service.CreateContact();
    }
}