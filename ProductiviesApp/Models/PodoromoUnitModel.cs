using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Models;

public class PodoromoUnitModel : ViewModelBase
{
    private int _parts;

    public int Parts
    {
        get => _parts;
        set => SetProperty(ref _parts, value);
    }

    private int _completedParts;

    public int CompletedParts
    {
        get => _completedParts;
        set => SetProperty(ref _completedParts, value);
    }

    private DateTime _timer;

    public DateTime Timer
    {
        get => _timer;
        set => SetProperty(ref _timer, value);
    }
}