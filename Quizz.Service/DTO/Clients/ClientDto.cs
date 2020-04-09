namespace Quizz.Service.DTOS
{
  public class ClientDto
  {
    public int Id { get; set; }
    public int TypeClientId { get; set; }
    public string Adresse { get; set; }
    public string Ville { get; set; }
    public string Quartier { get; set; }
    public string CodePostal { get; set; }
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public string MotPasse { get; set; }
    public bool EstActif { get; set; } 
  }
}