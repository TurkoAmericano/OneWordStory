using OneWordStory.Data.Repositories;
using OneWordStory.Emails;
using OneWordStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneWordStory.Services
{

  public interface IUserService
  {
    void CreateInvitedUsers(List<string> emails);
  }

  public class UserService : IUserService
  {

    private readonly IEmailer _emailer;
    private readonly IUserRepository _userRepository;

    public UserService(IEmailer emailer, IUserRepository userRepository)
    {
      _emailer = emailer;
      _userRepository = userRepository;
    }

    public void CreateInvitedUsers(List<string> emails)
    {
      _emailer.SendInvitiationEmails(emails);

      foreach (var email in emails)
      {
        _userRepository.CreateUser(new User() { Email = email  });
      }

      
    }
  }
}
