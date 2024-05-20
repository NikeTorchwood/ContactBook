using ConsoleApp2.Services.ServicesAbstractions;

namespace ConsoleApp2.Services.ServicesImplementations.Commands;

public class DeleteContact : IAppCommand
{
    private readonly IContactService _service;

    public DeleteContact(IContactService service)
    {
        _service = service;
    }

    public string GetCommandTitle() => "Удаление контакта";

    public void Invoke()
    {
        _service.ShowContacts();
        _service.DeleteContact();
        _service.ShowContacts();
    }
}