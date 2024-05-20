using ConsoleApp2.Services.ServicesImplementations.Menu;

namespace ConsoleApp2.Services.ServicesAbstractions;

public abstract class MenuState
{
    public List<IAppCommand> Commands { get; set; }
    public string Title { get; set; }

    public abstract void ChangeMenu(MenuContext menuContext);
}