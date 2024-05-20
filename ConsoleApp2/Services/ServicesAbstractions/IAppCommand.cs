namespace ConsoleApp2.Services.ServicesAbstractions;

public interface IAppCommand
{
    public string GetCommandTitle();
    public void Invoke();
}