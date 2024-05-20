using ConsoleApp2.Services.ServicesAbstractions;

namespace ConsoleApp2.Services.ServicesImplementations.Menu;

public class UserInterface : IUserInterface
{
    private string _topMenu;

    public void PrintScreen(string topMenu = default)
    {
        if (topMenu != default)
        {
            _topMenu = topMenu;
        }
        Console.SetCursorPosition(0, 0);
        ClearTop();
        Console.WriteLine(_topMenu);
        var halfScreen = Console.WindowHeight / 2;
        Console.SetCursorPosition(0, halfScreen);
        Console.WriteLine(new string('_', Console.WindowWidth));
    }

    public void ClearTop()
    {
        var halfScreen = Console.WindowHeight / 2;
        var clearString = new string(' ', Console.WindowWidth);
        for (var i = 0; i < Console.WindowHeight - halfScreen; i++)
        {
            Console.WriteLine(clearString);
        }
        Console.SetCursorPosition(0, 0);
    }
    public void ClearBottom()
    {
        var halfScreen = Console.WindowHeight / 2;
        var clearString = new string(' ', Console.WindowWidth);
        for (var i = 0; i < Console.WindowHeight - halfScreen - 2; i++)
        {
            Console.WriteLine(clearString);
        }
        Console.SetCursorPosition(0, halfScreen + 1);
    }
}