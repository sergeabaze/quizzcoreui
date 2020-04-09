using System.ComponentModel.DataAnnotations;
namespace Quizz.UI.Areas.Administration.Models
{
  public class MenuEditViewModel
  {
    public int Id { get; set; }
    [Display(Name = "Code")]
    [Required(ErrorMessage="Le Code est Requis")]
    public string Code { get; set; }
    [Required(ErrorMessage="Libéllé Requis")]
    [Display(Name = "Libéllé")]
    public string Libelle { get; set; }
  }

}
