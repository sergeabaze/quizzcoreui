using System.Collections.Generic;

namespace Quizz.UI.Models.ComptesViewModel
{
  public class UtilisateurViewModel
  {
    public int Id { get; set; }
    public int SocieteId { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public bool EstCompteActif { get; set; }
    public List<ProfileUtilisateurViewModel> ProfileEmployes { get; set; }
  }
}