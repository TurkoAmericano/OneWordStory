using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Data.SQL
{

  public interface IStorySQL
  {
    string CreateStory { get; }
    string InsertWord { get; }
    string GetLastPlacement { get; }
    string AddUserToStory { get; }
  }

  public class StorySQL : IStorySQL
  {
    public string CreateStory => @"INSERT INTO [dbo].[Story]
           ([Title])
              VALUES
           (@Title);
          SELECT SCOPE_IDENTITY();";

    public string InsertWord => @"INSERT INTO [dbo].[Story_Words]
           ([StoryId]
           ,[WordId]
           ,[PlacementOrder])
     VALUES
           (@StoryId
           ,@WordId
           ,@PlacementOrder)";

    public string GetLastPlacement => @"select max(PlacementOrder) from Story_Words where StoryId = @StoryId";

    public string AddUserToStory => @"INSERT INTO [dbo].[Story_Users]
           ([StoryId]
           ,[UserId]
           ,[TurnOrder]
           ,[IsCurrentTurn])
     VALUES
           (@StoryId
           ,@UserId
           ,@TurnOrder
           ,@IsCurrentTurn)";
  }
}
