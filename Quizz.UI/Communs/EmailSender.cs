using System.Threading.Tasks;

namespace Quizz.UI.Services
{
  public class EmailSender : IEmailSender
  {
    
    public Task SendEmailAsync(string email, string subject, string message)
    {
      return Task.CompletedTask;
    }
  }
}