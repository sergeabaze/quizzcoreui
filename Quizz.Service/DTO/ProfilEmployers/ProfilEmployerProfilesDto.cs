namespace Quizz.Service.DTOS
{
  public class ProfilEmployerProfilesDto
  {
    public int Id { get; set; }
    public int ProfilId{get;set;}
    public int EmployerId { get; set; }
    public ProfilListDto Profile { get; set; }
  }
}