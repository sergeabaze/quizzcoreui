using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;
using System.Linq;

namespace Quizz.UI.Areas.Administration.ProfilEmployer.Traducteur
{
  public class ProfilEmployerTraducteur : IProfilEmployerTraducteur
  {
    public ProfilEmployerDto TraduitVersDto(ProfilEmployerRequetteViewModel viewModel)
    {
      ProfilEmployerDto dto = null;
      if (viewModel != null)
      {
        dto = new ProfilEmployerDto();
        dto.Id = viewModel.Id;
        dto.ProfilId = viewModel.ProfilId;
        dto.EmployerId = viewModel.EmployerId;
      }
      return dto;
    }
    public ProfilEmployerRequetteViewModel TraduitVersViewModel(ProfilEmployerDto dto)
    {
      ProfilEmployerRequetteViewModel viewmodel = null;
      if (dto != null)
      {
        viewmodel = new ProfilEmployerRequetteViewModel();
        viewmodel.Id = dto.Id;
        viewmodel.ProfilId = dto.ProfilId;
        viewmodel.EmployerId = dto.EmployerId;
      }
      return viewmodel;
    }
    public List<ProfilEmployerListeViewModel> TraduitListeVersViewModel(List<ProfilEmployerListDto> dtolist)
    {
      List<ProfilEmployerListeViewModel> modelList = null;
      if (dtolist != null)
      {
        modelList = new List<ProfilEmployerListeViewModel>();
        foreach (var item in dtolist)
        {
          modelList.Add(new ProfilEmployerListeViewModel { Id = item.Id, ProfilId = item.ProfilId, EmployerId = item.EmployerId });
        }
      }
      return modelList;
    }


    public MessagePaginationViewModel<List<ProfilEmployerAfficheViewModel>> FromListe(PagedResponse<ProfilEmployerDto> dtos)
    {
      var resultats = new MessagePaginationViewModel<List<ProfilEmployerAfficheViewModel>>();
      if (dtos.Model == null || dtos.Model.ToList().Count == 0)
      {
        resultats.Messages = new List<MessageErreurs>(){
                        new MessageErreurs{
                            Code=MessageCode.CODE_ERREUR_101,
                            Libelle="Pas de données"
                        }
                    };
        resultats.EstErreur = true;
        return resultats;
      }
      resultats.EstErreur = dtos.DidError;
      if (resultats.EstErreur)
      {
        resultats.Messages = new List<MessageErreurs>(){
                        new MessageErreurs{
                            Code=MessageCode.CODE_ERREUR_TECHNIQUE,
                            Libelle=dtos.ErrorMessage
                        }
                    };
      }

      resultats.Model = new List<ProfilEmployerAfficheViewModel>();
      dtos.Model.ToList().ForEach(item =>
      {
        resultats.Model.Add(new ProfilEmployerAfficheViewModel
        {
          Id = item.Id,
          ProfilId = item.ProfilId,
          EmployerId = item.EmployerId
        });
      });
      resultats.PageCount = dtos.PageCount;
      resultats.PageNumber = dtos.PageNumber;
      resultats.ItemCount = dtos.ItemsCount;
      resultats.PageSize = dtos.PageSize;
      return resultats;
    }
    public MessageviewModel<ProfilEmployerRequetteViewModel> FromID(SingleResponse<ProfilEmployerDto> dto)
    {
      var model = new MessageviewModel<ProfilEmployerRequetteViewModel>();
      if (dto.Model == null)
      {
        model.Messages = new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_101,
                        Libelle="Pas de donnée(s)"
                    }
                };
        model.EstErreur = true;
        return model;
      }
      model.EstErreur = dto.DidError;
      if (model.EstErreur)
      {
        model.Messages = new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_TECHNIQUE,
                        Libelle=dto.ErrorMessage
                    }
                };
        return model;
      }
      model.Message = dto.ErrorMessage;
      model.Model = new ProfilEmployerRequetteViewModel
      {
        Id = dto.Model.Id,
        ProfilId = dto.Model.ProfilId,
        EmployerId = dto.Model.EmployerId
      };
      return model;
    }
    public MessageviewModel<ProfilEmployerRequetteViewModel> TraduitResultatPost(SingleResponse<ProfilEmployerDto> dto)
    {
      var model = new MessageviewModel<ProfilEmployerRequetteViewModel>();
      if (dto.Model == null)
      {
        model.Messages = new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_101,
                        Libelle="Pas de donnée(s)"
                    }
                };
        model.EstErreur = true;
        return model;
      }
      model.EstErreur = dto.DidError;
      if (model.EstErreur)
      {
        model.Messages = new List<MessageErreurs>(){
                    new MessageErreurs{
                        Code=MessageCode.CODE_ERREUR_TECHNIQUE,
                        Libelle=dto.ErrorMessage
                    }
                };
        return model;
      }
      model.Model = new ProfilEmployerRequetteViewModel
      {
        Id = dto.Model.Id,
        ProfilId = dto.Model.ProfilId,
        EmployerId = dto.Model.EmployerId
      };
      return model;
    }
  }
}
