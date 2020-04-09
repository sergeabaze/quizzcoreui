using System.Collections.Generic;
namespace Quizz.Service.DTOS
{
  public class ProfilListDto
  {
    public int TypeProfileId { get; set; }
    public TypeProfilDto TypeProfile{get;set;}
    public int Id{get;set;}
    public string Code { get; set; }
    public string Libelle { get; set; }
    public List<DroitDto> Droits{get;set;}
  }
}