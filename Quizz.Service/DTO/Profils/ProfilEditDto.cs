using System.Collections.Generic;
namespace Quizz.Service.DTOS
{
  public class ProfilEditDto
  {
    public int TypeProfilId{get;set;}
    public int Id { get; set; }
    public string Code { get; set; }
    public string Libelle { get; set; }
    public List<TypeProfilDto> TypeProfils{get;set;}
    public List<DroitDto> Droits{get;set;}
  }
}