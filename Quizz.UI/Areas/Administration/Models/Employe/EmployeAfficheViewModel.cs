using System.ComponentModel.DataAnnotations;

namespace Quizz.UI.Areas.Administration.Models
{
  public class EmployeAfficheViewModel
  {
    public int Id { get; set; }

    [Display(Name = "Societe")]
    public string Societe { get; set; }

    [Display(Name = "Employe")]
    public string TypeEmploye { get; set; }
    public string Nom { get; set; }
    public string Matricule { get; set; }

    [Display(Name = "E-mail")]
    public string Email { get; set; }

    [Display(Name = "Telephone")]
    public string Telephone1 { get; set; }
    public bool EstCompteActif { get; set; }
    public bool EstCompteSupprimer { get; set; }
   
  }

}