using System.Collections.Generic;
using System.Linq;
using Quizz.Service.DTOS;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;

namespace Quizz.UI.Areas.Administration.Traducteur
{
  public class SocieteTraducteur:ISocieteTraducteur
  {
    public SocieteTraducteur(){
      
    }
      public SocieteDto TraduitVersDto(SocieteRequetteViewModel viewModel){
          SocieteDto dto=null;
          if(viewModel!=null){
              dto=new SocieteDto{
                Id=dto.Id,
                Designation=dto.Designation,
                RaisonSociale=dto.RaisonSociale,
                NumeroContribuable=dto.NumeroContribuable,
                Adresse=dto.Adresse,
                Pays=dto.Pays,
                Ville=dto.Ville,
                Quartier=dto.Quartier,
                Rue=dto.Rue,
                Telephone1=dto.Telephone1,
                Telephone2=dto.Telephone2,
                BoitePostale=dto.BoitePostale,
                Faxe=dto.Faxe,
                Email=dto.Email,
                SiteWeb=dto.SiteWeb,
                MiseJourPar=dto.MiseJourPar
            };
        }
       return dto;
      }
    
      public SocieteRequetteViewModel TraduitVersViewModel(SocieteDto dto){
        SocieteRequetteViewModel viewModel=null;
        if(dto!=null)
        {
          viewModel=new SocieteRequetteViewModel
          {
              Id=dto.Id,
              Designation=dto.Designation,
              RaisonSociale=dto.RaisonSociale,
              NumeroContribuable=dto.NumeroContribuable,
             /* Adresse=dto.Adresse,
              Pays=dto.Pays,
              Ville=dto.Ville,
              Quartier=dto.Quartier,
              Rue=dto.Rue,
              Telephone1=dto.Telephone1,
              Telephone2=dto.Telephone2,
              BoitePostale=dto.BoitePostale,
              Faxe=dto.Faxe,
              Email=dto.Email,
              SiteWeb=dto.SiteWeb,
              MiseJourPar=dto.MiseJourPar*/
         };
        }
         return viewModel;
      }
      
      public List<SocieteListeViewModel> TraduitListeVersViewModel(List<SocieteListDto> dtolist){
        List<SocieteListeViewModel> viewModelList=null;
        if(dtolist!=null){
          viewModelList=new List<SocieteListeViewModel>();
          foreach (var item in dtolist)
          {
              viewModelList.Add(new SocieteListeViewModel{
                  Id=item.Id,
                  Designation=item.Designation,
                  RaisonSociale=item.RaisonSociale,
                  NumeroContribuable=item.NumeroContribuable,
                 /* Telephone1=item.Telephone1,
                  Pays=item.Pays,
                  Ville=item.Ville,
                  Email=item.Email */
              });
          }
        }
        return viewModelList;
      } 


      public  MessagePaginationViewModel<List<SocieteAfficheViewModel>> FromListe(PagedResponse<SocieteDto> dtos)
      {
         var resultats=new   MessagePaginationViewModel<List<SocieteAfficheViewModel>>();
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

                resultats.Model=new List<SocieteAfficheViewModel>();
                dtos.Model.ToList().ForEach(item=>{
                    resultats.Model.Add(new SocieteAfficheViewModel{
                        Id=item.Id,
                        Designation=item.Designation,
                        RaisonSociale=item.RaisonSociale,
                        NumeroContribuable=item.NumeroContribuable,
                        Telephone1=item.Telephone1,
                        Pays=item.Pays,
                        Ville=item.Ville,
                        Email=item.Email 
                    });
                });
                resultats.PageCount=dtos.PageCount;
                resultats.PageNumber=dtos.PageNumber;
                resultats.ItemCount=dtos.ItemsCount;
                resultats.PageSize=dtos.PageSize;
                return resultats;
      }

      public MessageviewModel<SocieteRequetteViewModel> FromID(SingleResponse<SocieteDto> dto)
      {
         var model=new MessageviewModel<SocieteRequetteViewModel>();
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
            model.Model=new SocieteRequetteViewModel{
                Id=dto.Model.Id,
                Designation=dto.Model.Designation,
                RaisonSociale=dto.Model.RaisonSociale,
                NumeroContribuable=dto.Model.NumeroContribuable,
              /*  Adresse=dto.Model.Adresse,
                Pays=dto.Model.Pays,
                Ville=dto.Model.Ville,
                Quartier=dto.Model.Quartier,
                Rue=dto.Model.Rue,
                Telephone1=dto.Model.Telephone1,
                Telephone2=dto.Model.Telephone2,
                BoitePostale=dto.Model.BoitePostale,
                Faxe=dto.Model.Faxe,
                Email=dto.Model.Email,
                SiteWeb=dto.Model.SiteWeb,
                MiseJourPar=dto.Model.MiseJourPar*/
            };
            return model;
      }

      public MessageviewModel<SocieteRequetteViewModel> TraduitResultatPost(SingleResponse<SocieteDto> dto)
      {
        var model=new MessageviewModel<SocieteRequetteViewModel>();
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
            model.Model=new SocieteRequetteViewModel{
                Id=dto.Model.Id,
                Designation=dto.Model.Designation,
                RaisonSociale=dto.Model.RaisonSociale,
                NumeroContribuable=dto.Model.NumeroContribuable,
               /* Adresse=dto.Model.Adresse,
                Pays=dto.Model.Pays,
                Ville=dto.Model.Ville,
                Quartier=dto.Model.Quartier,
                Rue=dto.Model.Rue,
                Telephone1=dto.Model.Telephone1,
                Telephone2=dto.Model.Telephone2,
                BoitePostale=dto.Model.BoitePostale,
                Faxe=dto.Model.Faxe,
                Email=dto.Model.Email,
                SiteWeb=dto.Model.SiteWeb,
                MiseJourPar=dto.Model.MiseJourPar*/
            };
            return model;
      }

  }
}