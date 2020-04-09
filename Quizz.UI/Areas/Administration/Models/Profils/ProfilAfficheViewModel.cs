using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class ProfilAfficheViewModel
  {
     public int TypeProfileId { get; set; }
     public TypeProfilRequetteViewModel TypeProfile{get;set;}
     public int Id{get;set;}
     public string Code { get; set; }
     public string Libelle { get; set; }
     public List<DroitRequetteViewModel> Droits{get;set;}
    
    
    /*public List<ProfilListeViewModel> Profils{get;set;}
    public List<TypeProfilRequetteViewModel> TypeProfils{get;set;}*/
  }
}
