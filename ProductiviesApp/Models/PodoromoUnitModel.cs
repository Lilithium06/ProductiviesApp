using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Models;

public class PodoromoUnitModel : ViewModelBase
{
    public int Parts { get; set; }

    public int CompletedParts { get; set; }

    private DateTime _timer;

    public DateTime Timer
    {
        get => _timer;
        set => SetProperty(ref _timer, value);
    }
}