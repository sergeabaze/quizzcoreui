using System.Collections.Generic;
using System.Linq;
using Quizz.Service.DTOS;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;

namespace Quizz.UI.Areas.Administration.Traducteur
{
  public class EmployeTraducteur : IEmployeTraducteur
  {

    public EmployeTraducteur(){
      
    }

    public MessageviewModel<EmployerequetteViewModel> FromID(SingleResponse<EmployeDto> dto)
    {
      var model = new MessageviewModel<EmployerequetteViewModel>();
      model.EstErreur = dto.DidError;
      if (model.EstErreur)
      {
        model.Messages = new List<MessageErreurs>(){new MessageErreurs
        { Code = MessageCode.CODE_ERREUR_TECHNIQUE, Libelle = dto.ErrorMessage } };
        return model;
      }

      model.Model = new EmployerequetteViewModel
      {
        Id = dto.Model.Id,
        Nom = dto.Model.Nom,
        SocieteId = dto.Model.SocieteId,
        TypeEmployeId = dto.Model.TypeEmployeId,
        Prenom = dto.Model.Prenom,
        Matricule = dto.Model.Matricule,
        Email = dto.Model.Email,
        Telephone1 = dto.Model.Telephone1,
        Telephone2 = dto.Model.Telephone2,
        EstCompteActif = dto.Model.EstCompteActif,
        EstCompteSupprimer = dto.Model.EstCompteSupprimer,
        DateCreation = dto.Model.DateCreation,
        CreePar = dto.Model.CreePar,
        DateMiseJour = dto.Model.DateMiseJour,
        MiseJourPar = dto.Model.MiseJourPar,
        DateDerniereConnection = dto.Model.DateDerniereConnection,
        DatePremierConnection = dto.Model.DatePremierConnection,
        RowVersion = dto.Model.RowVersion
      };

      return model;
    }

    public MessagePaginationViewModel<List<EmployeAfficheViewModel>> FromListe(PagedResponse<EmployeListeDto> dtos)
    {
      var resultats = new MessagePaginationViewModel<List<EmployeAfficheViewModel>>();
      resultats.EstErreur = dtos.DidError;

      if (!resultats.EstErreur)
      {
        resultats.Model = new List<EmployeAfficheViewModel>();
        dtos.Model.ToList().ForEach(item =>
        {
          resultats.Model.Add(new EmployeAfficheViewModel { Id = item.Id, Societe = item.Societe, 
                                                              TypeEmploye = item.TypeEmploye, Nom = item.Nom,
                                                              Matricule = item.Matricule, Email = item.Email,
                                                              Telephone1 = item.Telephone1, EstCompteActif = item.EstCompteActif,
                                                              EstCompteSupprimer = item.EstCompteSupprimer
                                                                });
        });
      }
        if (resultats.EstErreur)
        {
        resultats.Messages = new List<MessageErreurs>(){new MessageErreurs
        { Code = MessageCode.CODE_ERREUR_TECHNIQUE, Libelle = dtos.ErrorMessage } };
        return resultats;
      }
      resultats.PageCount = dtos.PageCount;
      resultats.PageNumber = dtos.PageNumber;
      resultats.ItemCount = dtos.ItemsCount;
      resultats.PageSize = dtos.PageSize;
      return resultats;
    }

   

    public MessageviewModel<EmployeReponseViewModel> TraduitResultat(SingleResponse<EmployeDto> dto)
    {
      var model = new MessageviewModel<EmployeReponseViewModel>();
      model.EstErreur = dto.DidError;
      if (model.EstErreur)
      {
        model.Messages = new List<MessageErreurs>(){new MessageErreurs
        { Code = MessageCode.CODE_ERREUR_TECHNIQUE, Libelle = dto.ErrorMessage } };
        return model;
      }

      model.Model = new EmployeReponseViewModel
      {
        Id = dto.Model.Id,
        Nom = dto.Model.Nom,
        SocieteId = dto.Model.SocieteId,
        TypeEmployeId = dto.Model.TypeEmployeId,
      };

      return model;
    }

    public EmployeCreationDto TraduitVers(EmployeCreationViewModel viewModel)
    {
      EmployeCreationDto entite = null;
      if(viewModel == null)
       return entite;

       entite = new EmployeCreationDto
      {
        Id = viewModel.Id,
        Nom = viewModel.Nom,
        SocieteId = viewModel.SocieteId,
        TypeEmployeId = viewModel.TypeEmployeId,
        Prenom = viewModel.Prenom,
        Matricule = viewModel.Matricule,
        Email = viewModel.Email,
        Telephone1 = viewModel.Telephone1,
        Telephone2 = viewModel.Telephone2,
        EstCompteActif = viewModel.EstCompteActif,
        EstCompteSupprimer = viewModel.EstCompteSupprimer,
        CreePar = viewModel.CreePar,

      };
      return entite;
    }

    public EmployeEditionDto TraduitEditVers(EmployeEditionViewModel viewModel)
    {
      EmployeEditionDto entite = null;
      if (viewModel == null)
        return entite;

       entite = new EmployeEditionDto
      {
        Id = viewModel.Id,
        Nom = viewModel.Nom,
        SocieteId = viewModel.SocieteId,
        TypeEmployeId = viewModel.TypeEmployeId,
        Prenom = viewModel.Prenom,
        Matricule = viewModel.Matricule,
        Email = viewModel.Email,
        Telephone1 = viewModel.Telephone1,
        Telephone2 = viewModel.Telephone2,
        EstCompteActif = viewModel.EstCompteActif,
        EstCompteSupprimer = viewModel.EstCompteSupprimer,
        MiseJourPar = viewModel.MiseJourPar,

      };

      return entite;
    }

    public EmployeEditionViewModel TraduitVersViewModel(EmployerequetteViewModel dto)
    {
      EmployeEditionViewModel model = null;
      model = new EmployeEditionViewModel
      {
        Id = dto.Id,
        Nom = dto.Nom,
        SocieteId = dto.SocieteId,
        TypeEmployeId = dto.TypeEmployeId,
        Prenom = dto.Prenom,
        Matricule = dto.Matricule,
        Email = dto.Email,
        Telephone1 = dto.Telephone1,
        Telephone2 = dto.Telephone2,
        EstCompteActif = dto.EstCompteActif,
        EstCompteSupprimer = dto.EstCompteSupprimer,
        DateCreation = dto.DateCreation,
        CreePar = dto.CreePar,
        DateMiseJour = dto.DateMiseJour,
        MiseJourPar = dto.MiseJourPar,
        
      };
      return model;
    }
  }

}