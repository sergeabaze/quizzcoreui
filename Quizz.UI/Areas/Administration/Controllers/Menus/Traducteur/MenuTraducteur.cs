using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using System.Linq;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Menu.Traducteur
{
  public class MenuTraducteur:IMenuTraducteur
  { 
    public MenuDto TraduitVersDto(MenuRequetteViewModel viewModel)
    {
        MenuDto dto=null;
        if(viewModel!=null)
        {
            dto=new MenuDto();
            dto.Id=viewModel.Id;
            dto.Code=viewModel.Code;
            dto.Libelle=viewModel.Libelle;
        }
        return dto;
    }
    public MenuRequetteViewModel TraduitVersViewModel(MenuDto dto)
    {
        MenuRequetteViewModel viewmodel=null;
        if(dto!=null) {
            viewmodel=new MenuRequetteViewModel();
            viewmodel.Id=dto.Id;
            viewmodel.Code=dto.Code;
            viewmodel.Libelle=dto.Libelle;
        }
        return viewmodel;
    }
    public List<MenuListeViewModel> TraduitListeVersViewModel(List<MenuListDto> dtolist)
    {
        List<MenuListeViewModel> modelList=null;
        if(dtolist!=null){
           modelList=new List<MenuListeViewModel>();
           foreach (var item in dtolist){
               modelList.Add(new MenuListeViewModel{Id=item.Id,Code=item.Code,Libelle=item.Libelle});
           }
        }
        return modelList;
    }

    
        public MessagePaginationViewModel<List<MenuAfficheViewModel>> FromListe(PagedResponse<MenuDto> dtos)
        {
                var resultats=new   MessagePaginationViewModel<List<MenuAfficheViewModel>>();
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

                resultats.Model=new List<MenuAfficheViewModel>();
                dtos.Model.ToList().ForEach(item=>{
                    resultats.Model.Add(new MenuAfficheViewModel{
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
    
        public  MessageviewModel<MenuRequetteViewModel> FromID(SingleResponse<MenuDto> dto)
        {
            var model=new MessageviewModel<MenuRequetteViewModel>();
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
            model.Model=new MenuRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }

        public MessageviewModel<MenuRequetteViewModel> TraduitResultatPost(SingleResponse<MenuDto> dto)
        {
            var model=new MessageviewModel<MenuRequetteViewModel>();
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
            model.Model=new MenuRequetteViewModel{
                Id=dto.Model.Id,
                Code=dto.Model.Code,
                Libelle=dto.Model.Libelle
            };
            return model;
        }


  }
}