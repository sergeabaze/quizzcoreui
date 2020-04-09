using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class ClientListeViewModel
  {
    public int Id { get; set; }
    public string TypeClient { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public string Email { get; set; }
    public string Telephone1 { get; set; }
    public string Ville{get;set;}
  }
}