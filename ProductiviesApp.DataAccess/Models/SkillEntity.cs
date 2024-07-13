using SQLite;

namespace ProductiviesApp.DataAccess.Models;

public class SkillEntity
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }
}