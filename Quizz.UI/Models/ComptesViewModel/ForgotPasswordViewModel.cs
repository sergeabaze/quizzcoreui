using System.ComponentModel.DataAnnotations;

namespace Quizz.UI.Models.ComptesViewModel
{
  public class ForgotPasswordViewModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }
  }
}