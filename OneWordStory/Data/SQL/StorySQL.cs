using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Data.SQL
{

  public interface IStorySQL
  {

  }

  public class StorySQL : IStorySQL
  {
    public string CreateStory => @"INSERT INTO [dbo].[Story]
           ([Title])
              VALUES
           (@Title)";
  }

}
