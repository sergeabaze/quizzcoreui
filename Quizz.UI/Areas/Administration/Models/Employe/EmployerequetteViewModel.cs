using System;

namespace Quizz.UI.Areas.Administration.Models
{
  public class EmployerequetteViewModel
  {
    public int Id { get; set; }
    public int SocieteId { get; set; }
    public int TypeEmployeId { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Matricule { get; set; }
    public string MotPasse { get; set; }
    public string Email { get; set; }
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public bool EstCompteActif { get; set; }
    public bool EstCompteSupprimer { get; set; }

    public DateTime? DatePremierConnection { get; set; }
    public DateTime? DateDerniereConnection { get; set; }
    public DateTime DateCreation { get; set; }
    public string CreePar { get; set; }
    public DateTime? DateMiseJour { get; set; }
    public string MiseJourPar { get; set; }
    public byte[] RowVersion { get; set; }
  }

}