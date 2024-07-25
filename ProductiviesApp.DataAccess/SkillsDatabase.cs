﻿using ProductiviesApp.DataAccess.Entities;
using SQLite;

namespace ProductiviesApp.DataAccess;

public class SkillsDatabase
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

    public async Task<List<SkillEntity>> GetSkillsAsync()
    {
        await Init();
        return await Database.Table<SkillEntity>().ToListAsync();
    }

    public async Task<SkillEntity> GetSkillByIdAsync(Guid id)
    {
        await Init();
        return await Database.Table<SkillEntity>().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<int> SaveSkillAsync(SkillEntity skill)
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