namespace Quizz.Service.DTOS
{
  public class SocieteReponseDto
  {
     public string Message {get;set;}
     public bool DidError {get;set;}
     public bool ErrorBad {get;set;}
     public bool errorNotFound {get;set;}
     public string  ErrorMessage{get;set;}
     public SocieteListDto Model{get;set;} 
  }
}