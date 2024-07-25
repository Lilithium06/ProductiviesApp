namespace ProductiviesApp.Commands;

public class GoToPageCommand(string route) : BaseCommand
{
    private readonly string _route = route;

    public override async void Execute(object? parameter) => await Shell.Current.GoToAsync(_route);
}