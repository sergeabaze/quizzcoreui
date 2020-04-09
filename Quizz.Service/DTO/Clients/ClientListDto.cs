namespace Quizz.Service.DTOS
{
  public class ClientListDto
  {
    public int Id { get; set; }
    public string TypeClient { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public string Email { get; set; }
    public string Telephone1 { get; set; }
    public string Ville{get;set;}
  }
}