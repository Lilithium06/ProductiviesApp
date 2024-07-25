﻿using ProductiviesApp.Models;
using System.Windows.Input;

namespace ProductiviesApp.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    public MainPageViewModel()
    {
        _podoromoUnitModel = new PodoromoUnitModel()
        {
            Timer = new DateTime(1, 1, 1, 0, 0, 12)
        };
        _timer = Application.Current?.Dispatcher.CreateTimer() ?? throw new ArgumentNullException();

        _startTimer = new Command(() =>
        {
            _timer.Tick += RemoveOneSecond;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Start();
        });
    }

    private PodoromoUnitModel _podoromoUnitModel;

    public PodoromoUnitModel PodoromoUnitModel
    {
        get => _podoromoUnitModel;
        set => SetProperty(ref _podoromoUnitModel, value);
    }

    private ICommand _startTimer;

    public ICommand StartTimer
    {
        get => _startTimer;
        set => SetProperty(ref _startTimer, value);
    }

    private readonly IDispatcherTimer _timer;

    private void RemoveOneSecond(object? o, EventArgs e)
    {
        if (PodoromoUnitModel.Timer.Minute == 0 && PodoromoUnitModel.Timer.Second == 0)
        {
            _timer.Stop();
            PodoromoUnitModel.CompletedParts++;

            if (PodoromoUnitModel.Parts == PodoromoUnitModel.CompletedParts)
            {
                //Do stuff that gives extra exp
            }

            return;
        }

        PodoromoUnitModel.Timer = PodoromoUnitModel.Timer.AddSeconds(-1);
    }
}