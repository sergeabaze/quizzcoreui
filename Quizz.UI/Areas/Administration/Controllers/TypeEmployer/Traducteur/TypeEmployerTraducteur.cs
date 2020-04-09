using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS; 
using System.Linq;
using Quizz.UI.Areas.Administration.Models; 

namespace Quizz.UI.Areas.Administration.TypeEmployer.Traducteur
{
  public class TypeEmployerTraducteur:ITypeEmployerTraducteur
  { 
    public TypeEmployerDto TraduitVersDto(TypeEmployerRequetteViewModel viewModel){
        TypeEmployerDto dto=null;
        if(viewModel!=null){
            dto=new TypeEmployerDto();
            dto.Id=viewModel.Id;
            dto.Code=viewModel.Code;
            dto.Libelle=viewModel.Libelle;
        }
        return dto;
    }
    public TypeEmployerRequetteViewModel TraduitVersViewModel(TypeEmployerDto dto){
        TypeEmployerRequetteViewModel viewmodel=null;
        if(dto!=null) {
            viewmodel=new TypeEmployerRequetteViewModel();
            viewmodel.Id=dto.Id;
            viewmodel.Code=dto.Code;
            viewmodel.Libelle=dto.Libelle;
        }
        return viewmodel;
    }
    public List<TypeEmployerListeViewModel> TraduitListeVersViewModel(List<TypeEmployerListDto> dtolist){
         List<TypeEmployerListeViewModel> modelList=null;
        if(dtolist!=null){
           modelList=new List<TypeEmployerListeViewModel>();
           foreach (var item in dtolist){
               modelList.Add(new TypeEmployerListeViewModel{Id=item.Id,Code=item.Code,Libelle=item.Libelle});
           }
        }
        return modelList;
    }

    
    public MessagePaginationViewModel<List<TypeEmployerAfficheViewModel>> FromListe(PagedResponse<TypeEmployerDto> dtos)
    {
            var resultats=new   MessagePaginationViewModel<List<TypeEmployerAfficheViewModel>>();
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

                resultats.Model=new List<TypeEmployerAfficheViewModel>();
                dtos.Model.ToList().ForEach(item=>{
                    resultats.Model.Add(new TypeEmployerAfficheViewModel{
                        Id=item.Id,
                        Code=item.Code,
                        Libelle=item.Libelle
                    });
                });
                resultats.PageCount=dtos.PageCount;
                resultats.PageNumber=dtos.PageNumber;
                resultats.ItemCount=dtos.ItemsCount;
                resultats.PageSize=dtos.PageSize;
                return resultats;
        }  
    
        public  MessageviewModel<TypeEmployerRequetteViewModel> FromID(SingleResponse<TypeEmployerDto> dto)
        {
            var model=new MessageviewModel<TypeEmployerRequetteViewModel>();
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
            model.Model=new TypeEmployerRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }

        public MessageviewModel<TypeEmployerRequetteViewModel> TraduitResultatPost(SingleResponse<TypeEmployerDto> dto)
        {
            var model=new MessageviewModel<TypeEmployerRequetteViewModel>();
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
            model.Model=new TypeEmployerRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }


  }
}