using System.ComponentModel.DataAnnotations;

namespace Quizz.UI.Areas.Administration.Models
{
  public class ProfilReponseViewModel
  {
    public string Message {get;set;}
    public bool DidError {get;set;}
    public bool ErrorBad {get;set;}
    public bool errorNotFound {get;set;}
    public string  ErrorMessage{get;set;}
    public ProfilListeViewModel Model{get;set;}
  }
}
