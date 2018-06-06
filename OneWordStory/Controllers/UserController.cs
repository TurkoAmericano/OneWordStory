using OneWordStory.Data.Repositories;
using OneWordStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneWordStory.Controllers
{
  public class UserController : Controller
  {

    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [Route("api/get-user-by-token/{token}")]
    public JsonResult GetUserByToken(string token)
    {
      var user = _userRepository.GetUserByToken(token);
      return Json(user);
    }

    [HttpPost]
    [Route("api/create-user/")]
    public JsonResult CreateUser(User user)
    {
      
      return Json(user);
    }

  }
}
