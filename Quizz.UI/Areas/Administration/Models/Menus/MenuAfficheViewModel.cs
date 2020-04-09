using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class MenuAfficheViewModel
  {
   public int Id { get; set; } 
    public string Code { get; set; } 
    public string Libelle { get; set; }
  }
}