using System.ComponentModel.DataAnnotations;
using Quizz.Service.DTOS;
namespace Quizz.UI.Areas.Administration.Models
{
  public class TypeEmployerReponseViewModel
  {
     public string Message {get;set;}
     public bool DidError {get;set;}
     public bool ErrorBad {get;set;}
     public bool errorNotFound {get;set;}
     public string  ErrorMessage{get;set;}
     public TypeEmployerListDto Model{get;set;} 
  }
}