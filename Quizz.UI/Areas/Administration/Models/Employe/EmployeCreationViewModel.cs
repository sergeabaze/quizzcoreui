using System.ComponentModel.DataAnnotations;
using Quizz.Service.Enums;

namespace Quizz.UI.Areas.Administration.Models
{
  public class EmployeCreationViewModel
  {
    public int Id { get; set; }
    public int SocieteId { get; set; }
    public int TypeEmployeId { get; set; }

    [Required(ErrorMessage = "Le Nom est un champ requis")]
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Matricule { get; set; }
    public string MotPasse { get; set; }
    [Required(ErrorMessage = "Le Email est un champ requis")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Le Téléphone1 est un champ requis")]
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public bool EstCompteActif { get; set; }
    public bool EstCompteSupprimer { get; set; }
    public string CreePar { get; set; }
    [EnumDataType(typeof(TypeEmployeEnum))]
    public TypeEmployeEnum TypeEmployes { get; set; }
  }

}