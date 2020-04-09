namespace Quizz.Service.DTOS
{
  public class SocieteListDto
  {
    public int    Id { get; set; }
    public string Designation { get; set; }
    public string RaisonSociale { get; set; }
    public string NumeroContribuable { get; set; }
    public string Pays { get; set; }
    public string Ville { get; set; }
    public string Telephone1 { get; set; }
    public string Email { get; set; }
  }
}