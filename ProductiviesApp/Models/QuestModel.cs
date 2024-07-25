﻿using ProductiviesApp.ViewModels;
using System.Collections.ObjectModel;

namespace ProductiviesApp.Models;

public class QuestModel : ViewModelBase
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

    private string _details = string.Empty;

    public string Details
    {
        get => _details;
        set => SetProperty(ref _details, value);
    }

    private ObservableCollection<Difficulty> _difficulty = [];

    public ObservableCollection<Difficulty> Difficulty
    {
        get => _difficulty;
        set => SetProperty(ref _difficulty, value);
    }

    private ObservableCollection<SkillModel> _neededSkills = [];

    public ObservableCollection<SkillModel> NeededSkills
    {
        get => _neededSkills;
        set => SetProperty(ref _neededSkills, value);
    }
}