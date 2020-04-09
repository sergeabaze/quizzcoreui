using System.ComponentModel.DataAnnotations;

namespace Quizz.UI.Areas.Administration.Models
{
  public class ProfilRequetteViewModel
  {
    public int Id { get; set; }
    [Display(Name="Type Profil")] 
    public int TypeProfilId{get;set;}
    [Display(Name = "Code")]
    public string Code { get; set; }
    [Display(Name = "Libelle")]
    public string Libelle { get; set; } 
  }
}

