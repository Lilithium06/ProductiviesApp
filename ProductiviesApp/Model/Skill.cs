﻿namespace ProductiviesApp.Model;

public class Skill
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public int Exp { get; set; }

    public List<Quest> NeededInQuests { get; set; } = [];
}