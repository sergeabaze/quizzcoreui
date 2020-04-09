namespace Quizz.Service.DTOS
{
  public class TypeProfilReponseDto
  {
    public string Message {get;set;}
     public bool DidError {get;set;}
     public bool ErrorBad {get;set;}
     public bool errorNotFound {get;set;}
     public string  ErrorMessage{get;set;}
     public TypeProfilListDto Model{get;set;} 
  }  
}