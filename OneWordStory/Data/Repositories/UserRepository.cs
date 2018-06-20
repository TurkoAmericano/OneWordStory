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
    User GetUserByToken(string token);
    int CreateUser(User user, IDbTransaction transaction = null);
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

    public int CreateUser(User user, IDbTransaction transaction = null)
    {
      using (var db = new SqlConnection(_connectionString))
      {
        return db.Query<int>(_userSql.CreateUser, user, transaction: transaction).FirstOrDefault();
      }
    }

  }
}
