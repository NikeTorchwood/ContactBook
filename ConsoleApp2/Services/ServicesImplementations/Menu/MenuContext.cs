using ConsoleApp2.Services.ServicesAbstractions;

namespace ConsoleApp2.Services.ServicesImplementations.Menu;

public class MenuContext(MenuState startMenuState)
{
    public MenuState MenuState { get; set; } = startMenuState;

    public void ProcessState(int command)
    {
        MenuState.Commands[command].Invoke();
        MenuState.ChangeMenu(this);
    }
}