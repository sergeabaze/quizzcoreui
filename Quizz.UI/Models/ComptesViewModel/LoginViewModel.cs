using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Quizz.UI.Models.ComptesViewModel
{
  public class LoginViewModel
  {
    [Required]
    [EmailAddress]
    [JsonProperty("email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [JsonProperty("motPasse")]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
    public bool EstEmploye { get; set; }
  }
}