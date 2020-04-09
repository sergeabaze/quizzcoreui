using System.Collections.Generic;

namespace Quizz.UI.DTO
{
  public class EmployeLoginDto
  {
    public int Id { get; set; }
    public int SocieteId { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public bool EstCompteActif { get; set; }
    public List<ProfileEmployeLoginDto> ProfilEmployes { get; set; }
  }

}