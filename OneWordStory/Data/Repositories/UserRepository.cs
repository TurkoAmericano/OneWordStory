using OneWordStory.Models;
using System;
using Dapper;
using System.Linq;
using System.Web.Configuration;
using System.Data.SqlClient;
using OneWordStory.Data.SQL;

namespace OneWordStory.Data.Repositories
{

  public interface IUserRepository
  {
    User GetUserByToken(string token);
    void CreateUser(User user);
    User LoginUser(User user);
  }

  public class UserRepository : IUserRepository
  {

    string _connectionString;
    IUserSQL _userSql;

    public UserRepository(IUserSQL userSql)
    {
      _userSql = userSql;
      _connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
    }

    public User GetUserByToken(string token)
    {
      using (var db = new SqlConnection(_connectionString))
      {
        var user = db.Query<User>(_userSql.GetUserByToken, new { Token = token }).FirstOrDefault();
        return user;
      }
    }

    public User LoginUser(User user)
    {
      using (var db = new SqlConnection(_connectionString))
      {
        var returnValue = db.Query<User>(_userSql.LoginUser, user).FirstOrDefault();
        return returnValue;
      }
    }

    public void CreateUser(User user)
    {
      using (var db = new SqlConnection(_connectionString))
      {
        db.Query<User>(_userSql.CreateUser, user).FirstOrDefault();
      }
    }

  }
}
