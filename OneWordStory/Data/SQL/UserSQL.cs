using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Data.SQL
{

  public interface IUserSQL
  {
    string GetUserByToken { get;  }
  }

  public class UserSQL : IUserSQL
  {
    public string GetUserByToken => @"SELECT UserId
      ,FirstName
      ,LastName
      ,Email
      ,Token
      FROM User where Token = @Token";

  }
}
