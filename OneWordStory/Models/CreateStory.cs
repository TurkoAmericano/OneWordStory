using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Models
{
  public class CreateStory
  {
    public string Title { get; set; }
    public string FirstWord { get; set; }
    public List<string> Emails { get; set; }
  }
}
