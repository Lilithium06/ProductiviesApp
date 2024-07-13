using ProductiviesApp.DataAccess.Models;
using SQLite;

namespace ProductiviesApp.DataAccess;

public class SkillsDatabase
{
    private SQLiteAsyncConnection Database;
    
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<SkillEntity>();
    }

    public async Task<List<SkillEntity>> GetSkillsAsync()
    {
        await Init();
        return await Database.Table<SkillEntity>().ToListAsync();
    }

    public async Task<int> SaveItemAsync(SkillEntity skill)
    {
        await Init();
        if (skill.Id != Guid.Empty)
            return await Database.UpdateAsync(skill);
        else
            return await Database.InsertAsync(skill);
    }

    public async Task<int> DeleteSkillAsync(SkillEntity skill)
    {
        await Init();
        return await Database.DeleteAsync(skill);
    }
}