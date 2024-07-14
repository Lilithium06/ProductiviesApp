using ProductiviesApp.DataAccess.Entities;
using SQLite;

namespace ProductiviesApp.DataAccess;

public class QuestDatabase
{
    private SQLiteAsyncConnection Database;
    
    async Task Init()
    {
        if (Database is not null)
            return;
        
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        
        await Database.CreateTableAsync<SkillEntity>();
        await Database.CreateTableAsync<QuestEntity>();
        await Database.CreateTableAsync<QuestSkillEntity>();
    }

    public async Task<List<QuestEntity>> GetQuestAsync()
    {
        await Init();
        return await Database.Table<QuestEntity>().ToListAsync();
    }

    public async Task<int> SaveQuestAsync(QuestEntity quest)
    {
        await Init();
        if (quest.Id != Guid.Empty)
            return await Database.UpdateAsync(quest);
        else
            return await Database.InsertAsync(quest);
    }

    public async Task<int> DeleteQuestAsync(QuestEntity quest)
    {
        await Init();
        return await Database.DeleteAsync(quest);
    }
}