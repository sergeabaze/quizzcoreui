

using System.Collections.Generic;

namespace Quizz.UI.Models.ComptesViewModel
{
  public class ProfileViewModel
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Libelle { get; set; }
    public List<DroitsViewModel> Droits { get; set; }
  }
}