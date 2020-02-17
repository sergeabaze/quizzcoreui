using System.Threading.Tasks;

namespace Quizz.UI.Services
{
  public interface IEmailSender
  {
    Task SendEmailAsync(string email, string subject, string message);
  }
}