using System.ComponentModel.DataAnnotations;

namespace Quizz.UI.Areas.Administration.Models
{
  public class SocieteRequetteViewModel
  {
    public int Id { get; set; }
    [Display(Name = "Release Date")]
    public string Designation { get; set; }
    public string RaisonSociale { get; set; }
    public string NumeroContribuable { get; set; }
    public string Telephone { get; set; }
  }

}
