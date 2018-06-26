using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Models
{
  public class AddUserToStory
  {

    public int StoryId { get; set; }
    public int UserId { get; set; }
    public int TurnOrder { get; set; }
    public bool IsCurrentTurn { get; set; }

  }
}
