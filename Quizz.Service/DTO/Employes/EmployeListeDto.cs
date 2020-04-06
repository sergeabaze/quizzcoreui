namespace Quizz.Service.DTOS
{
  public class EmployeListeDto
  {
    public int Id { get; set; }
    public string Societe { get; set; }
    public string TypeEmploye { get; set; }
    public string Nom { get; set; }
    public string Matricule { get; set; }
    public string Email { get; set; }
    public string Telephone1 { get; set; }
    public bool EstCompteActif { get; set; }
    public bool EstCompteSupprimer { get; set; }

  }

}