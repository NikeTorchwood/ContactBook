using System.Threading.Channels;
using ConsoleApp2.Services.RepositoriesAbstractions;
using ConsoleApp2.Services.ServicesAbstractions;
using ConsoleApp2.Services.ServicesImplementations.Commands;

namespace ConsoleApp2.Services.ServicesImplementations.Menu;

public class MainMenuState : MenuState
{
    private readonly IContactService _service;

    public MainMenuState(IContactService service)
    {
        _service = service;
        Commands =
        [
            new ShowContacts(_service),
            new CreateContact(_service),
            new UpdateContact(_service),
            new DeleteContact(service),
            //new SortContats(service)
        ];
        Title =
            @"-------------------------------------------------------------
--------------------Телефонный справочник--------------------
-------------------------------------------------------------";
    }
    public override void ChangeMenu(MenuContext menuContext)
    {
        menuContext.MenuState = new MainMenuState(_service);
    }
}