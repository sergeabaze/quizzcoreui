namespace Quizz.UI.Models.ComptesViewModel
{
  public class DroitsViewModel
  {public int Id { get; set; }
    public int ProfileId { get; set; }
    public int MenuId { get; set; }

    public string Code { get; set; }
    public string Libelle { get; set; }
    public bool Ecriture { get; set; }
    public bool Lecture { get; set; }
    public bool Suppression { get; set; }
    public bool Impression { get; set; }
    public bool ExecutionImport { get; set; }
    public bool ExecutionRapport { get; set; }
    public MenuViewModel Menu { get; set; }
  }
}