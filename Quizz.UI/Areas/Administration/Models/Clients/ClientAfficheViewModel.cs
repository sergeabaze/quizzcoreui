using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Quizz.UI.Areas.Administration.Models
{
  public class ClientAfficheViewModel
  {
    public List<MenuRequetteViewModel> Menus{get;set;}
  }
}