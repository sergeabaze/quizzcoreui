using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class ProfilEditViewModel
  {
    public int Id { get; set; }
    [Display(Name="Type Profil")]
    [Required(ErrorMessage="Type Profil est Requis")]
    public int TypeProfilId{get;set;}
    [Display(Name = "Code")] 
    [Required(ErrorMessage="Code Requis")]
    public string Code { get; set; }
    [Display(Name = "Libellé")] 
    [Required(ErrorMessage="Libellé Requis")]
    public string Libelle { get; set; }     
    public List<TypeProfilRequetteViewModel> TypeProfils{get;set;}
  }

}
