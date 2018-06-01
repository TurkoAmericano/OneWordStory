using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneWordStory.Controllers
{
  public class UserController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Title = "Home Page";

      return View();
    }
  }
}
