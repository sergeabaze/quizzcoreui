using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Quizz.UI.Areas.Administration.Models
{
  public class ProfilListeViewModel
  {
    [Display(Name="Type Profil")] 
    public int TypeProfileId { get; set; }
    public TypeProfilListeViewModel TypeProfile{get;set;}
    public int Id{get;set;}
    [Display(Name = "Code")]
    public string Code { get; set; }
    [Display(Name = "Libelle")]
    public string Libelle { get; set; }
    public List<DroitListeViewModel> Droits{get;set;} 
  }
}
