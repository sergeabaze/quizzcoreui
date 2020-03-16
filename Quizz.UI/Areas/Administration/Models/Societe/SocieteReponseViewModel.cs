using System.ComponentModel.DataAnnotations;

namespace Quizz.UI.Areas.Administration.Models
{
  public class SocieteReponseViewModel
  {
    public int Id { get; set; }
    public string Designation { get; set; }
    public string RaisonSociale { get; set; }
    public string NumeroContribuable { get; set; }
    public string Telephone { get; set; } 
  }
    
}