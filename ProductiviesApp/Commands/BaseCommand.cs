using System.Windows.Input;

namespace ProductiviesApp.Commands;

public class BaseCommand : ICommand
{
    public virtual bool CanExecute(object? parameter) => true;

    public virtual void Execute(object? parameter) => throw new NotImplementedException();

    public event EventHandler? CanExecuteChanged;
}