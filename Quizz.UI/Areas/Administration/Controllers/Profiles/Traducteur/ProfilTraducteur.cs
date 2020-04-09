using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using System.Linq;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Profil.Traducteur
{
  public class ProfilTraducteur:IProfilTraducteur
  { 
    public ProfilDto TraduitVersDto(ProfilRequetteViewModel viewModel)
    {
        ProfilDto dto=null;
        if(viewModel!=null) {
            dto=new ProfilDto{
                Id=viewModel.Id,
                Code=viewModel.Code,
                Libelle=viewModel.Libelle,
                TypeProfilId=viewModel.TypeProfilId
            };
        }
        return dto;
    }
    public ProfilRequetteViewModel TraduitVersViewModel(ProfilDto dto)
    {
        ProfilRequetteViewModel viewModel=null;
        if(dto!=null) {
            viewModel=new ProfilRequetteViewModel{
                Id=dto.Id,
                Code=dto.Code,
                Libelle=dto.Libelle,
                TypeProfilId=dto.TypeProfilId
            };
        }
        return viewModel;
    }

    public List<ProfilListeViewModel> TraduitListeVersViewModel(List<ProfilListDto> dtolist)
    {
        List<ProfilListeViewModel> viewModelList=null;
        if(dtolist!=null){
            viewModelList=new List<ProfilListeViewModel>();
            
            foreach (var item in dtolist){
                //mapping des droits du profil
                List<DroitListeViewModel> droits=null;
                if(item.Droits!=null){
                    droits=new List<DroitListeViewModel>();
                    foreach (var droit in item.Droits){
                        droits.Add(new DroitListeViewModel{
                                Id =droit.Id, 
                                ProfileId=droit.ProfileId,
                                MenuId=droit.MenuId,
                                Lecture=droit.Lecture,  
                                Ecriture=droit.Ecriture,  
                                Modification=droit.Modification,  
                                Suppression=droit.Suppression,  
                                Consultation=droit.Consultation , 
                                Impression=droit.Impression, 
                                ExecutionRapport=droit.ExecutionRapport,
                                ExecutionImport=droit.ExecutionImport
                        });
                    }
                }
               //mapping du type de profil
               TypeProfilListeViewModel typeProfilViewModel=null;
                if(item.TypeProfile!=null){
                    typeProfilViewModel=new TypeProfilListeViewModel {
                        Id=item.TypeProfile.Id,
                        Code=item.TypeProfile.Code,
                        Libelle=item.TypeProfile.Libelle
                    };
                } 
               viewModelList.Add(new ProfilListeViewModel{
                   TypeProfileId=item.TypeProfileId,
                   Id=item.Id,
                   Code=item.Code,
                   Libelle=item.Libelle,
                   TypeProfile=typeProfilViewModel,
                   Droits=droits
               });
            }
        }
        return viewModelList;
    }
    
   



    public MessagePaginationViewModel<List<ProfilAfficheViewModel>> FromListe(PagedResponse<ProfilListDto> dtos)
    {
            var resultats=new   MessagePaginationViewModel<List<ProfilAfficheViewModel>>();
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

            resultats.Model=new List<ProfilAfficheViewModel>();
            dtos.Model.ToList().ForEach(item=>{
                resultats.Model.Add(new ProfilAfficheViewModel{
                    Id=item.Id,
                    Code=item.Code,
                    Libelle=item.Libelle,
                    TypeProfileId=item.TypeProfileId,
                    TypeProfile=new TypeProfilRequetteViewModel {
                        Id=item.TypeProfile.Id,
                        Code=item.TypeProfile.Code,
                        Libelle=item.TypeProfile.Libelle
                    },
                    Droits=item.Droits.Select(viewModel=>new DroitRequetteViewModel{
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
                    }).ToList()
                });
            });
            resultats.PageCount=dtos.PageCount;
            resultats.PageNumber=dtos.PageNumber;
            resultats.ItemCount=dtos.ItemsCount;
            resultats.PageSize=dtos.PageSize;
            return resultats;
        }  
    
        public  MessageviewModel<ProfilRequetteViewModel> FromID(SingleResponse<ProfilDto> dto)
        {
            var model=new MessageviewModel<ProfilRequetteViewModel>();
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
            model.Model=new ProfilRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }

        public MessageviewModel<ProfilRequetteViewModel> TraduitResultatPost(SingleResponse<ProfilDto> dto)
        {
            var model=new MessageviewModel<ProfilRequetteViewModel>();
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
            model.Model=new ProfilRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }

  }
}
