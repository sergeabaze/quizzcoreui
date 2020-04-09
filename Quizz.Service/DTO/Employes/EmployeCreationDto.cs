namespace Quizz.Service.DTOS
{
  public class EmployeCreationDto
  {
    public int Id { get; set; }
    public int SocieteId { get; set; }
    public int TypeEmployeId { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Matricule { get; set; }

    public string Email { get; set; }
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public bool EstCompteActif { get; set; }
    public bool EstCompteSupprimer { get; set; }
    public string CreePar { get; set; }

  }

}