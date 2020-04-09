using System.Collections.Generic;

namespace Quizz.UI.Models.ComptesViewModel
{
  public class UtilisateurDto
  {
    public bool DidError { get; set; }
    public string Message { get; set; }
    public string ErrorMessage { get; set; }
    public bool ErrorBad { get; set; }
    public bool ErrorNotFound { get; set; }
  }
}