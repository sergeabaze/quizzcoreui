using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class DroitAfficheViewModel
  {
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int MenuId { get; set; }
    public bool Lecture { get; set; }
    public bool Ecriture { get; set; }
    public bool Modification { get; set; }
    public bool Suppression { get; set; }
    public bool Consultation { get; set; }
    public bool Impression { get; set; }
    public bool ExecutionRapport { get; set; }
    public bool ExecutionImport { get; set; }

  /*  public List<DroitRequetteViewModel> Droits{get;set;}
      public List<ProfilRequetteViewModel> Profils{get;set;}
      public List<MenuRequetteViewModel> Menus{get;set;} 
    */
  }
}