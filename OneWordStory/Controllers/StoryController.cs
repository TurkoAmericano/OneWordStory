using OneWordStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OneWordStory.Controllers
{
    public class StoryController : ApiController
    {

    [HttpPost]
    [Route("api/create-story/")]
    public string CreateUser(CreateStory user)
    {



      return "";
      
    }

  }
}
