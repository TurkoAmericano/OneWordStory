using OneWordStory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OneWordStory.Data.Repositories
{

  public interface IStoryRepository
  {
    void CreateStory(CreateStory story, IDbTransaction transaction = null);
  }

  public class StoryRepository : IStoryRepository
  {
    public void CreateStory(CreateStory story, IDbTransaction transaction = null)
    {
      
    }
  }
}
