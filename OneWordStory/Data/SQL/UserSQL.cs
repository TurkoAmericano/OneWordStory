using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Data.SQL
{

  public interface IUserSQL
  {
    string GetUserByToken { get;  }
    string CreateUser { get; }
  }

  public class UserSQL : IUserSQL
  {
    public string GetUserByToken => @"SELECT UserId
      ,FirstName
      ,LastName
      ,Email
      ,Token
      FROM User where Token = @Token";

    public string CreateUser => @"INSERT INTO [User]
           (FirstName
           ,LastName
           ,Email
           ,Password
           ,Token)
     VALUES
           (@FirstName
           ,@LastName
           ,@Email
           ,@Password
           ,@Token)";


    public string LoginUser => @"SELECT UserId
      ,FirstName
      ,LastName
      ,Email
      ,Token
      FROM [User] where Email = @Email and Password = @Password";

  }
}
