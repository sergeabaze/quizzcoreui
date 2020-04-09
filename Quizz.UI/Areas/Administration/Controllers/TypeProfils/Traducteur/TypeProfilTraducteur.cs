using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using System.Linq;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.TypeProfil.Traducteur
{
  public class TypeProfilTraducteur:ITypeProfilTraducteur
  { 
    public TypeProfilDto TraduitVersDto(TypeProfilRequetteViewModel viewModel){
        TypeProfilDto dto=null;
        if(viewModel!=null){
            dto=new TypeProfilDto();
            dto.Id=viewModel.Id;
            dto.Code=viewModel.Code;
            dto.Libelle=viewModel.Libelle;
        }
        return dto;
    }
    
        public TypeProfilRequetteViewModel TraduitVersViewModel(TypeProfilDto dto){
            TypeProfilRequetteViewModel viewmodel=null;
            if(dto!=null) {
                viewmodel=new TypeProfilRequetteViewModel();
                viewmodel.Id=dto.Id;
                viewmodel.Code=dto.Code;
                viewmodel.Libelle=dto.Libelle;
            }
            return viewmodel;
        }

        public List<TypeProfilListeViewModel> TraduitListeVersViewModel(List<TypeProfilListDto> dtolist){
            List<TypeProfilListeViewModel> modelList=null;
            if(dtolist!=null){
            modelList=new List<TypeProfilListeViewModel>();
            foreach (var item in dtolist){
                modelList.Add(new TypeProfilListeViewModel{Id=item.Id,Code=item.Code,Libelle=item.Libelle});
            }
            }
            return modelList;
        }

        public MessagePaginationViewModel<List<TypeProfilAfficheViewModel>> FromListe(PagedResponse<TypeProfilDto> dtos)
        {
                var resultats=new   MessagePaginationViewModel<List<TypeProfilAfficheViewModel>>();
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

                resultats.Model=new List<TypeProfilAfficheViewModel>();
                dtos.Model.ToList().ForEach(item=>{
                    resultats.Model.Add(new TypeProfilAfficheViewModel{
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
    
        public  MessageviewModel<TypeProfilRequetteViewModel> FromID(SingleResponse<TypeProfilDto> dto)
        {
            var model=new MessageviewModel<TypeProfilRequetteViewModel>();
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
            model.Model=new TypeProfilRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }

        public MessageviewModel<TypeProfilRequetteViewModel> TraduitResultatPost(SingleResponse<TypeProfilDto> dto)
        {
            var model=new MessageviewModel<TypeProfilRequetteViewModel>();
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
            model.Model=new TypeProfilRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }
    }
}