using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Models
{
  public class User
  {

    public User()
    {
      FirstName = "";
      LastName = "";
      Password = "";

    }

    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }

  }
}
