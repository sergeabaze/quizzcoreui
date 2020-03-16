using System.Collections.Generic;
using System.Net;
using Quizz.UI.Models;

namespace Quizz.UI.Services
{
  public static class GestionStatuthttpmessage
  {
      public static string ObtenireMessageStatuscode(HttpStatusCode statusCode){
        string _messageCode = null ;
          if (HttpStatusCode.NotFound == statusCode)
          {
            _messageCode = MessageCode.NOT_FOUND;
          }
          if (HttpStatusCode.NotImplemented == statusCode)
          {
            _messageCode = MessageCode.ERREUR_TECHNIQUE;
          }
          if (HttpStatusCode.BadRequest == statusCode)
          {
            _messageCode = MessageCode.ERREUR_TECHNIQUE;
          }
          return _messageCode;
    }

    public static MessageviewModel<T> ObtenireMessage<T>(HttpStatusCode statusCode, string messageErreur)
    {
      var message = new MessageviewModel<T>{
        EstErreur = true,
        Messages = new List<MessageErreurs>
          {
              new MessageErreurs
              {
                Code = ((int)statusCode).ToString(),
                Libelle = messageErreur
                 }
            }
      };
      return message;
     
    }

    public static MessagePaginationViewModel<T> ObtenirePaginationMessage<T>(HttpStatusCode statusCode, string messageErreur)
    {
      var message = new MessagePaginationViewModel<T>
      {
        EstErreur = true,
        Messages = new List<MessageErreurs>
          {
              new MessageErreurs
              {
                Code = ((int)statusCode).ToString(),
                Libelle = messageErreur
                 }
            }
      };
      return message;

    }


  }

}