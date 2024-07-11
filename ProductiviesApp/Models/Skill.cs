using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Models;

public class Skill : ViewModelBase
{
    public Skill(string name, int exp)
    {
        Name = name;
        Exp = exp;
        //Here I would calculate how much that level is because I am probably only going to save exp
        Level = 1;
    }
    
    private string _name;

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
}