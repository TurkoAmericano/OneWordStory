using OneWordStory.Data.Repositories;
using OneWordStory.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace OneWordStory.Controllers
{
  public class UserController : ApiController
  {
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [Route("api/get-user-by-token/{token}")]
    public User GetUserByToken(string token)
    {
      var user = _userRepository.GetUserByToken(token);
      return user;
    }

    [HttpPost]
    [Route("api/create-user/")]
    public string CreateUser(User user)
    {

      byte[] data = Encoding.ASCII.GetBytes(user.Password);
      data = new SHA256Managed().ComputeHash(data);
      user.Password = Encoding.ASCII.GetString(data);

      user.Token = Guid.NewGuid().ToString();

      _userRepository.CreateUser(user);
      return user.Token;
    }

    [HttpPost]
    [Route("api/login-user/")]
    public User LoginUser(User user)
    {

      byte[] data = Encoding.ASCII.GetBytes(user.Password);
      data = new SHA256Managed().ComputeHash(data);
      user.Password = Encoding.ASCII.GetString(data);

      user.Token = Guid.NewGuid().ToString();

      var returnUser = _userRepository.LoginUser(user);
      return returnUser;

    }

  }
}
