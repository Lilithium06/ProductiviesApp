using ProductiviesApp.DataAccess.Entities;
using SQLite;

namespace ProductiviesApp.DataAccess;

public class QuestDatabase
{
    private SQLiteAsyncConnection? _database;

    public SQLiteAsyncConnection Database
    {
        get { return _database ?? throw new ArgumentNullException(); }
        set { _database = value; }
    }

    private async Task Init()
    {
        if (_database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

        await Database.CreateTableAsync<SkillEntity>();
        await Database.CreateTableAsync<QuestEntity>();
        await Database.CreateTableAsync<QuestSkillEntity>();
    }

    public async Task<List<QuestEntity>> GetQuestAsync()
    {
        await Init();
        var quests = await Database.Table<QuestEntity>().ToListAsync();

        foreach (var quest in quests)
        {
            quest.NeededSkills = [];
            var questSkillEntities = await Database.Table<QuestSkillEntity>()
                .Where(qs => qs.QuestId == quest.Id)
                .ToListAsync();

            foreach (var questSkillEntity in questSkillEntities)
            {
                var skill = await Database.Table<SkillEntity>()
                    .Where(s => s.Id == questSkillEntity.SkillId)
                    .FirstOrDefaultAsync();
                if (skill != null)
                {
                    quest.NeededSkills.Add(skill);
                }
            }
        }

        return quests;
    }

    public async Task<int> SaveQuestAsync(QuestEntity quest)
    {
        await Init();

        int result;
        if (quest.Id != Guid.Empty)
        {
            result = await Database.UpdateAsync(quest);
        }
        else
        {
            result = await Database.InsertAsync(quest);
            quest.Id = (await Database.Table<QuestEntity>()
                .OrderByDescending(q => q.Id)
                .FirstAsync()).Id;
        }

        // Delete existing QuestSkillEntities for the quest
        await Database.Table<QuestSkillEntity>()
            .Where(qs => qs.QuestId == quest.Id)
            .DeleteAsync();

        // Insert new QuestSkillEntities for the quest
        foreach (var skill in quest.NeededSkills)
        {
            var questSkillEntity = new QuestSkillEntity
            {
                QuestId = quest.Id,
                SkillId = skill.Id
            };
            await Database.InsertAsync(questSkillEntity);
        }

        return result;
    }

    public async Task<int> DeleteQuestAsync(QuestEntity quest)
    {
        await Init();
        return await Database.DeleteAsync(quest);
    }
}