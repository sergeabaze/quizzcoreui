using System.ComponentModel.DataAnnotations;
namespace Quizz.UI.Areas.Administration.Models
{
  public class TypeProfilEditViewModel
  {
    public int Id { get; set; }
    [Display(Name = "Code")]
    [Required]
    public string Code { get; set; }
    [Required]
    [Display(Name = "Libéllé")]
    public string Libelle { get; set; }
  }

}
