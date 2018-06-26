using OneWordStory.Data.Repositories;
using OneWordStory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace OneWordStory.Controllers
{
  public class StoryController : ApiController
  {

    private readonly IDbConnection _dbConnection;
    private readonly IUserRepository _userRepository;
    private readonly IStoryRepository _storyRepository;

    public StoryController(IDbConnection dbConnection, IUserRepository userRepository, IStoryRepository storyRepository)
    {
      _dbConnection = dbConnection;
      _userRepository = userRepository;
      _storyRepository = storyRepository;
    }

    [HttpPost]
    [Route("api/create-story/")]
    public void CreateStory(CreateStory createStory)
    {

      using (var transaction = _dbConnection.BeginTransaction())
      {

        var storyId = _storyRepository.CreateStory(_dbConnection, createStory);

        _storyRepository.AddUserToStory(_dbConnection, new AddUserToStory() { IsCurrentTurn = false, StoryId = storyId, TurnOrder = 1, UserId = createStory.UserId });

        int counter = 1;
        foreach (var email in createStory.Emails)
        {
          counter++;
          var friendId = _userRepository.CreateUser(_dbConnection, new User() { Email = email });
          _userRepository.AddFriend(_dbConnection, createStory.UserId, friendId);
          _storyRepository.AddUserToStory(_dbConnection, new AddUserToStory() { IsCurrentTurn = counter == 2, UserId = friendId, StoryId = storyId, TurnOrder = counter });
        }
      }



    }
  }
}
