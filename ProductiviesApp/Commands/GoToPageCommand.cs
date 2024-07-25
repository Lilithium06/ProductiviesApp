namespace ProductiviesApp.Commands;

public class GoToPageCommand(string route) : BaseCommand
{
    private readonly string _route = route;

    public async void Execute()
    {
        await Shell.Current.GoToAsync(_route);
    }
}