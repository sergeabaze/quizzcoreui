using System.Collections.Generic;

namespace Quizz.UI.DTO
{
  public class ProfileLoginDto
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Libelle { get; set; }
    public List<DroitLoginDto> Droits { get; set; }
  }

}