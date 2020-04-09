using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class ProfilEmployerEditViewModel
  {
    public int Id { get; set; }
    public int ProfilId{get;set;}
    public int EmployerId { get; set; } 
    public List<TypeProfilRequetteViewModel> TypeProfils{get;set;}
  }
}