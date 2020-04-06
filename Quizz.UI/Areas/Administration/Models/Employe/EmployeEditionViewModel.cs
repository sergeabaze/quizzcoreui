using System;
using System.ComponentModel.DataAnnotations;

namespace Quizz.UI.Areas.Administration.Models
{
  public class EmployeEditionViewModel
  {
    public int Id { get; set; }
    public int SocieteId { get; set; }
    public int TypeEmployeId { get; set; }

    [Required(ErrorMessage = "Le Nom est un champ requis")]
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Matricule { get; set; }
   
    [Required(ErrorMessage = "Le Email est un champ requis")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Le Téléphone1 est un champ requis")]
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public bool EstCompteActif { get; set; }
    public bool EstCompteSupprimer { get; set; }
    public string MiseJourPar { get; set; }
    public DateTime DateCreation { get; set; }
    public string CreePar { get; set; }
    public DateTime? DateMiseJour { get; set; }
    
  }

}