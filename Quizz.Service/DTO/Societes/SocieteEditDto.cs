namespace Quizz.Service.DTOS
{
  public class SocieteEditDto
  {
    public int    Id { get; set; }
    public string Designation { get; set; }
    public string RaisonSociale { get; set; }
    public string NumeroContribuable { get; set; }
    public string Adresse { get; set; }
    public string Pays { get; set; }
    public string Ville { get; set; }
    public string Quartier { get; set; }
    public string Rue { get; set; }
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public string BoitePostale { get; set; }
    public string Faxe { get; set; }
    public string Email { get; set; }
    public string SiteWeb { get; set; }
    public string MiseJourPar { get; set; }
  }
}