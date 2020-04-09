using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class TypeProfilAfficheViewModel
  {
    public int Id { get; set; }
    [Display(Name = "Code")]
    public string Code { get; set; }
    [Display(Name = "Libelle")]
    public string Libelle { get; set; }
  }
}