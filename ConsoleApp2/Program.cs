using System.Text;
using ConsoleApp2.Infrastructure.Context;
using ConsoleApp2.Infrastructure.Repositorires.Implementations;
using ConsoleApp2.Services.ServicesAbstractions;
using ConsoleApp2.Services.ServicesImplementations;
using ConsoleApp2.Services.ServicesImplementations.Menu;

namespace ConsoleApp2;

public class Program
{
    public static void Main()
    {
        var contextManager = new ContextManager($"{Environment.CurrentDirectory}/contacts.json");
        var repository = new ContactRepository(contextManager);
        var service = new ContactService(repository);
        var context = new MenuContext(new MainMenuState(service));
        var ui = new UserInterface();
        var app = new ContactBookApp(context, ui);
        app.Run();
        Console.ReadKey();
    }
}

public class ContactBookApp(MenuContext menuContext, IUserInterface userInterface)
{
    private ConsoleKeyInfo _ki;
    private int _cursorPosition;

    public void Run()
    {
        do
        {
            do
            {
                userInterface.PrintScreen(CreateTop());
                ChooseMenuItem(menuContext.MenuState.Commands.Count);
            } while (_ki.Key != ConsoleKey.Enter);
            userInterface.ClearBottom();
            menuContext.ProcessState(_cursorPosition);
            _cursorPosition = 0;
        } while (true);
    }
    private string CreateTop()
    {
        var sb = new StringBuilder();
        sb.AppendLine(menuContext.MenuState.Title);
        sb.Append(GetCommandsTitles(_cursorPosition));
        return sb.ToString();
    }
    private void ChooseMenuItem(int itemsCount)
    {
        _ki = Console.ReadKey();
        switch (_ki.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.LeftArrow:
                if (_cursorPosition > 0)
                {
                    _cursorPosition--;
                }
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.DownArrow:
                if (_cursorPosition < itemsCount - 1)
                {
                    _cursorPosition++;
                }
                break;
            case ConsoleKey.Enter:
                break;
            default:
                Console.WriteLine("Введен некорректный ввод, для продолжения нажмите на стрелочки");
                Console.ReadKey();
                break;
        }
    }

    private string GetCommandsTitles(int cursorPosition)
    {
        var sb = new StringBuilder();
        var commands = menuContext.MenuState.Commands;
        for (var i = 0; i < commands.Count; i++)
        {
            var c = i == cursorPosition ? '>' : ' ';
            sb.AppendLine($"{c}{commands[i].GetCommandTitle()}");
        }
        return sb.ToString();
    }
}