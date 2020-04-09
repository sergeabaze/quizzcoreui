using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Quizz.UI.Models.ComptesViewModel
{
  public class ChangementMotPasseViewModel
  {
    public int Id { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Ancien password")]
    [JsonProperty("ancienmotpasse")]
    public string AncienMotpasse { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "nouveau password")]
    [JsonProperty("nouveaumotpasse")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [JsonProperty("confirmernouveaumotpasse")]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmerNouveauMotpasse { get; set; }
    public string MisejourPar { get; set; }
  }
}