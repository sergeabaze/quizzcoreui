

namespace Quizz.UI.Models.ComptesViewModel
{
  public class ProfileUtilisateurViewModel
  {
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int EmployeId { get; set; }
    public ProfileViewModel Profile { get; set; }
  }
}