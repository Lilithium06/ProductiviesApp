using ProductiviesApp.Model;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    public MainPageViewModel()
    {
        _dispatcherTimer = Application.Current?.Dispatcher.CreateTimer() ?? throw new ArgumentNullException();

        StartTimer = new Command(() =>
        {
            _dispatcherTimer.Tick += RemoveOneSecond;
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Start();
        });
    }

    public readonly PodoromoUnit PodoromoUnit = new();

    public ICommand StartTimer { get; }

    private readonly IDispatcherTimer _dispatcherTimer;

    private DateTime _timer = new(1, 1, 1, 0, 0, 12);

    public DateTime Timer
    {
        get { return _timer; }
        set { SetProperty(ref _timer, value); }
    }

    private void RemoveOneSecond(object? o, EventArgs e)
    {
        if (Timer.Minute == 0 && Timer.Second == 0)
        {
            _dispatcherTimer.Stop();
            PodoromoUnit.CompletedParts++;

            if (PodoromoUnit.Parts == PodoromoUnit.CompletedParts)
            {
                //Do stuff that gives extra exp
            }

            return;
        }

        Timer = Timer.AddSeconds(-1);
    }
}