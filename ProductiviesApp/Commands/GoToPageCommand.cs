using System.Windows.Input;

namespace ProductiviesApp.Commands;

public class GoToPageCommand : ICommand
{
    private readonly string _route;

    public GoToPageCommand(string route)
    {
        _route = route;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        await Shell.Current.GoToAsync(_route);
    }

    public event EventHandler? CanExecuteChanged;
}