using System.ComponentModel.DataAnnotations;
namespace Quizz.UI.Areas.Administration.Models
{
  public class TypeEmployerEditViewModel
  {
    public int Id { get; set; }
    [Display(Name = "Code")]
    [Required(ErrorMessage="Code Requis")]
    public string Code { get; set; }
    [Required(ErrorMessage="Libelle Requis")]
    [Display(Name = "Libéllé")]
    public string Libelle { get; set; }
  }
}