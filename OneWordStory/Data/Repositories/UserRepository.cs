using OneWordStory.Models;
using System;
using Dapper;
using System.Linq;
using System.Web.Configuration;
using System.Data.SqlClient;
using OneWordStory.Data.SQL;
using System.Data;

namespace OneWordStory.Data.Repositories
{

  public interface IUserRepository
  {
    User GetUserByToken(IDbConnection conn, string token);
    int CreateUser(IDbConnection conn, User user);
    User LoginUser(IDbConnection conn, User user);
    void AddFriend(IDbConnection conn, int userId, int friendId);
  }

  public class UserRepository : IUserRepository
  {

    IUserSQL _userSql;
    
    public UserRepository(IUserSQL userSql)
    {
      _userSql = userSql;
      
    }

    public User GetUserByToken(IDbConnection conn, string token)
    {
        var user = conn.Query<User>(_userSql.GetUserByToken, new { Token = token }).FirstOrDefault();
        return user;
    }

    public User LoginUser(IDbConnection conn, User user)
    {
        var returnValue = conn.Query<User>(_userSql.LoginUser, user).FirstOrDefault();
        return returnValue;
    }

    public int CreateUser(IDbConnection conn, User user)
    {
        return conn.Query<int>(_userSql.CreateUser, user).FirstOrDefault();
    }

    public void AddFriend(IDbConnection conn, int userId, int friendId)
    {
      conn.Execute(_userSql.AddFriend, new { UserId = userId, FriendId = friendId });
    }
  }
}
