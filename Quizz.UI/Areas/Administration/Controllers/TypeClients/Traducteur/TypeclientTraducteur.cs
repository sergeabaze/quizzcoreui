using System.Collections.Generic;
using System.Linq;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;

namespace Quizz.UI.Areas.Administration.TypeClient.Traducteur
{

  public class TypeClientTraducteur: ITypeClientTraducteur
  {
      public TypeClientTraducteur(){
        
      }

    public MessageviewModel<TypeClientRequetteViewModel> FromID(SingleResponse<TypeClientDto> dto)
    {
      var model = new MessageviewModel<TypeClientRequetteViewModel>();

      if(dto.Model ==null){
        model.Messages = new List<MessageErreurs>(){ new MessageErreurs 
        { Code = MessageCode.CODE_ERREUR_101,
         Libelle ="Pas de données"
         }};
         model.EstErreur =true;
        return model;
      }
      model.EstErreur = dto.DidError;
      if (model.EstErreur)
      {
        model.Messages = new List<MessageErreurs>(){new MessageErreurs
        { Code = MessageCode.CODE_ERREUR_TECHNIQUE, Libelle = dto.ErrorMessage } };
        return model;
      }
      model.Message = dto.ErrorMessage;
      model.Model = new TypeClientRequetteViewModel {
            Id = dto.Model.Id,
            Code = dto.Model.Code,
            Libelle = dto.Model.Libelle
          };
     
      return model;
    }

    public MessagePaginationViewModel<List<TypeClientAfficheViewModel>> FromListe(PagedResponse<TypeClientDto> dtos)
    {
      var resultats = new MessagePaginationViewModel<List<TypeClientAfficheViewModel>> ();
     
      if(dtos.Model == null || dtos.Model.ToList().Count == 0){
        resultats.Messages = new List<MessageErreurs>(){ new MessageErreurs
        { Code =MessageCode.CODE_ERREUR_101,
         Libelle ="Pas de données"
         }};
        resultats.EstErreur = true;
        return resultats;
      }

      resultats.EstErreur = dtos.DidError;
      if (resultats.EstErreur)
      {
        resultats.Messages = new List<MessageErreurs>(){new MessageErreurs
        { Code = MessageCode.CODE_ERREUR_TECHNIQUE, Libelle = dtos.ErrorMessage } };
        return resultats;
      }

       resultats.Model = new List<TypeClientAfficheViewModel>();
       dtos.Model.ToList().ForEach(item =>{
        resultats.Model.Add(new TypeClientAfficheViewModel{Id = item.Id, Code = item.Code, Libelle =item.Libelle});
      });
      resultats.PageCount = dtos.PageCount;
      resultats.PageNumber = dtos.PageNumber;
      resultats.ItemCount = dtos.ItemsCount;
      resultats.PageSize = dtos.PageSize;


      return resultats;
    }

    public MessageviewModel<TypeClientRequetteViewModel> TraduitResultatPost(SingleResponse<TypeClientDto> dto)
    {
      var model = new MessageviewModel<TypeClientRequetteViewModel>();

      if (dto.Model == null)
      {
        model.Messages = new List<MessageErreurs>(){ new MessageErreurs
        { Code = MessageCode.CODE_ERREUR_101,
         Libelle ="Pas de données"
         }};
        model.EstErreur = true;
        return model;
      }
      model.EstErreur = dto.DidError;
      if (model.EstErreur)
      {
        model.Messages = new List<MessageErreurs>(){new MessageErreurs
        { Code = MessageCode.CODE_ERREUR_TECHNIQUE, Libelle = dto.ErrorMessage } };
        return model;
      }

      model.Model = new TypeClientRequetteViewModel
      {
        Id = dto.Model.Id,
        Code = dto.Model.Code,
        Libelle = dto.Model.Libelle
      };

      return model;
    }

    public TypeClientRequetteDto TraduitVers(TypeClientRequetteViewModel viewModel)
    {
      var model =new TypeClientRequetteDto{ 
        Id = viewModel.Id,
         Code = viewModel.Code,
         Libelle = viewModel.Libelle
        };

        return model;
    }

   
  } 
  
  

}