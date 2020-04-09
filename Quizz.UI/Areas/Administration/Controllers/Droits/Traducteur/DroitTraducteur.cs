using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;
using System.Linq;

namespace Quizz.UI.Areas.Administration.Droit.Traducteur
{
  public class DroitTraducteur:IDroitTraducteur
  { 
    public DroitDto TraduitVersDto(DroitRequetteViewModel viewModel){
      DroitDto dto=null;
      if(viewModel!=null)
      {
          dto=new DroitDto{
                Id =viewModel.Id, 
                ProfileId=viewModel.ProfileId,
                MenuId=viewModel.MenuId,
                Lecture=viewModel.Lecture,  
                Ecriture=viewModel.Ecriture,  
                Modification=viewModel.Modification,  
                Suppression=viewModel.Suppression,  
                Consultation=viewModel.Consultation , 
                Impression=viewModel.Impression, 
                ExecutionRapport=viewModel.ExecutionRapport,
                ExecutionImport=viewModel.ExecutionImport
          };
      }
      return dto;
    }
    public DroitRequetteViewModel TraduitVersViewModel(DroitDto dto){
         DroitRequetteViewModel viewModel=null;
        if(dto!=null) {
            viewModel=new DroitRequetteViewModel{
            Id =dto.Id, 
            ProfileId=dto.ProfileId,
            MenuId=dto.MenuId,
            Lecture=dto.Lecture,  
            Ecriture=dto.Ecriture,  
            Modification=dto.Modification,  
            Suppression=dto.Suppression,  
            Consultation=dto.Consultation, 
            Impression=dto.Impression, 
            ExecutionRapport=dto.ExecutionRapport,
            ExecutionImport=dto.ExecutionImport
            };
        }
      return viewModel;
    }
    public List<DroitListeViewModel> TraduitListeVersViewModel(List<DroitListDto> dtolist){
        List<DroitListeViewModel> viewModelList=null;
        if(dtolist!=null){
            viewModelList=new List<DroitListeViewModel>();
            foreach (var item in dtolist) {
                viewModelList.Add(new DroitListeViewModel{
                    Id =item.Id, 
                    ProfileId=item.ProfileId,
                    MenuId=item.MenuId,
                    Lecture=item.Lecture,  
                    Ecriture=item.Ecriture,  
                    Modification=item.Modification,  
                    Suppression=item.Suppression,  
                    Consultation=item.Consultation, 
                    Impression=item.Impression, 
                    ExecutionRapport=item.ExecutionRapport,
                    ExecutionImport=item.ExecutionImport
                });
            }
        }
        return viewModelList;
    }

    public MessagePaginationViewModel<List<DroitAfficheViewModel>> FromListe(PagedResponse<DroitDto> dtos)
    {
      var resultats=new   MessagePaginationViewModel<List<DroitAfficheViewModel>>();
                if(dtos.Model==null || dtos.Model.ToList().Count==0){
                    resultats.Messages=new List<MessageErreurs>(){
                        new MessageErreurs{
                            Code=MessageCode.CODE_ERREUR_101,
                            Libelle="Pas de données"
                        }
                    };
                    resultats.EstErreur=true;
                    return resultats;
                }
                resultats.EstErreur=dtos.DidError;
                if(resultats.EstErreur){
                    resultats.Messages=new List<MessageErreurs>(){
                        new MessageErreurs{
                            Code=MessageCode.CODE_ERREUR_TECHNIQUE,
                            Libelle=dtos.ErrorMessage
                        }
                    };
                }

                resultats.Model=new List<DroitAfficheViewModel>();
                dtos.Model.ToList().ForEach(item=>{
                    resultats.Model.Add(new DroitAfficheViewModel{
                        Id =item.Id, 
                        ProfileId=item.ProfileId,
                        MenuId=item.MenuId,
                        Lecture=item.Lecture,  
                        Ecriture=item.Ecriture,  
                        Modification=item.Modification,  
                        Suppression=item.Suppression,  
                        Consultation=item.Consultation, 
                        Impression=item.Impression, 
                        ExecutionRapport=item.ExecutionRapport,
                        ExecutionImport=item.ExecutionImport
                    });
                });
                resultats.PageCount=dtos.PageCount;
                resultats.PageNumber=dtos.PageNumber;
                resultats.ItemCount=dtos.ItemsCount;
                resultats.PageSize=dtos.PageSize;
                return resultats;

    }
    public MessageviewModel<DroitRequetteViewModel> FromID(SingleResponse<DroitDto> dto)
    {
       var model=new MessageviewModel<DroitRequetteViewModel>();
            if(dto.Model==null) {
                model.Messages=new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_101,
                        Libelle="Pas de donnée(s)"
                    }
                };
                model.EstErreur=true;
                return model;
            }
            model.EstErreur=dto.DidError;
            if(model.EstErreur){
                model.Messages=new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_TECHNIQUE,
                        Libelle=dto.ErrorMessage
                    }
                };
                return model;
                }
            model.Message=dto.ErrorMessage;
            model.Model=new DroitRequetteViewModel{
                Id =dto.Model.Id, 
                ProfileId=dto.Model.ProfileId,
                MenuId=dto.Model.MenuId,
                Lecture=dto.Model.Lecture,  
                Ecriture=dto.Model.Ecriture,  
                Modification=dto.Model.Modification,  
                Suppression=dto.Model.Suppression,  
                Consultation=dto.Model.Consultation, 
                Impression=dto.Model.Impression, 
                ExecutionRapport=dto.Model.ExecutionRapport,
                ExecutionImport=dto.Model.ExecutionImport
            };
            return model;
    }
    public MessageviewModel<DroitRequetteViewModel> TraduitResultatPost(SingleResponse<DroitDto> dto)
    {
      var model=new MessageviewModel<DroitRequetteViewModel>();
            if(dto.Model==null)
            {
                model.Messages=new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_101,
                        Libelle="Pas de donnée(s)"
                    }
                };
                model.EstErreur=true;
                return model;
            }  
            model.EstErreur=dto.DidError;
            if(model.EstErreur){
                model.Messages=new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_TECHNIQUE,
                        Libelle=dto.ErrorMessage
                    }
                };
                return model;
            }
            model.Model=new DroitRequetteViewModel{
                Id =dto.Model.Id, 
                ProfileId=dto.Model.ProfileId,
                MenuId=dto.Model.MenuId,
                Lecture=dto.Model.Lecture,  
                Ecriture=dto.Model.Ecriture,  
                Modification=dto.Model.Modification,  
                Suppression=dto.Model.Suppression,  
                Consultation=dto.Model.Consultation, 
                Impression=dto.Model.Impression, 
                ExecutionRapport=dto.Model.ExecutionRapport,
                ExecutionImport=dto.Model.ExecutionImport
            };
            return model;
    }
  }
}
