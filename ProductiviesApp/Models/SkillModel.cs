﻿using ProductiviesApp.ViewModels;
using System.Collections.ObjectModel;

namespace ProductiviesApp.Models;

public class SkillModel : ViewModelBase
{
    private Guid _id;

    public Guid Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private int _level;

    public int Level
    {
        get => _level;
        set => SetProperty(ref _level, value);
    }

    private int _exp;

    public int Exp
    {
        get => _exp;
        set => SetProperty(ref _exp, value);
    }

    private ObservableCollection<QuestModel> _neededInQuests = [];

    public ObservableCollection<QuestModel> NeededInQuests
    {
        get => _neededInQuests;
        set => SetProperty(ref _neededInQuests, value);
    }
}