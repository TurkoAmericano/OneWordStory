using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OneWordStory.Emails
{

  public interface IEmailer
  {
    void SendInvitiationEmails(List<string> emails);
  }

  public class Emailer : IEmailer
  {

    public void SendInvitiationEmails(List<string> emails)
    {

      foreach (var email in emails)
      {

        var fromAddress = new MailAddress("1wordstorygame@gmail.com", "From Name");
        var toAddress = new MailAddress(email, email);
        const string fromPassword = "G7X4Gs4QOs4LETT8tPDJ";
        const string subject = "You've been invited to One Word Story";
        const string body = "You've been invited to join! Click <a href='http://localhost:8545/signup'>here</a>";

        var smtp = new SmtpClient
        {
          Host = "smtp.gmail.com",
          Port = 587,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          UseDefaultCredentials = false,
          Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
          Subject = subject,
          Body = body
        })
        {
          smtp.Send(message);
        }

      }


    }

  }
}
