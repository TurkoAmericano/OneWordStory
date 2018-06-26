using OneWordStory.Data.SQL;
using OneWordStory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace OneWordStory.Data.Repositories
{

  public interface IStoryRepository
  {
    int CreateStory(IDbConnection conn, CreateStory story);
    void AddWord(IDbConnection conn, int storyId, int wordId, int placementOrder);
    int GetLastPlacement(IDbConnection conn, int storyId);
    void AddUserToStory(IDbConnection conn, AddUserToStory addUserToStory);
  }

  public class StoryRepository : IStoryRepository
  {

    private readonly IStorySQL _storySql;

    public StoryRepository(IStorySQL storySql)
    {
      _storySql = storySql;
    }

    public void AddUserToStory(IDbConnection conn, AddUserToStory addUserToStory)
    {
      conn.Execute(_storySql.AddUserToStory, addUserToStory);
    }

    public void AddWord(IDbConnection conn, int storyId, int wordId, int placementOrder)
    {
      conn.Execute(_storySql.InsertWord, new { StoryId = storyId, WordId = wordId, PlacementOrder = placementOrder });
    }

    public int CreateStory(IDbConnection conn, CreateStory story)
    {
      return conn.Query<int>(_storySql.CreateStory, new { story.Title }).FirstOrDefault();
    }

    public int GetLastPlacement(IDbConnection conn, int storyId)
    {
      return conn.Query<int>(_storySql.GetLastPlacement, new { StoryId = storyId }).FirstOrDefault();
    }
  }
}
