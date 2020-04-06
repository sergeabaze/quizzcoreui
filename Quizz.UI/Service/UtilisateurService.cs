using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.UI.Models.ComptesViewModel;

namespace Quizz.UI.Services
{

  public  class UtilisateurService :IUtilisateurService
  {

    #region Proprietes

    private Uri BaseEndpoint { get; set; }
    private string BASE_API;
   
    private const string POST = "login";
    private const string PUT = "misejour/{0}";
    private readonly HttpRequestBuilder _requetteBilder;
   // private readonly IEmployeTraducteur _traducteur;
    private readonly MySettings _mySettings;


    #endregion

    #region Constructeurs


    public UtilisateurService(IOptions<MySettings> settings)
    {
      _requetteBilder = new HttpRequestBuilder();
      _mySettings = settings.Value;
      BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiEmployeUrl;
    }

    public UtilisateurService()
    {
      
      _mySettings = new MySettings()
      {
        ApiBaseUrl = "http://localhost:60/",
         ApiEmployeUrl = "api/v1/Employe/"
      };
      BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiEmployeUrl;
    }

    public async Task<MessageviewModel<UtilisateurViewModel>> EmployeLogin(LoginViewModel viewModel)
    {

      var requestUri = new Uri(BASE_API + POST);
      MessageviewModel<UtilisateurViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Post(requestUri.AbsoluteUri , viewModel);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        resultat = new MessageviewModel<UtilisateurViewModel>();
       
        var result = JsonConvert.DeserializeObject<SingleResponse<EmployeLoginDto>>(response);
        resultat = new MessageviewModel<UtilisateurViewModel>{
          Model = FromEntityLogin(result),
          EstErreur = false, 
          Message = "Connection reussie" 
          
        };
        
      }
      else
      {
       var resultErreur = JsonConvert.DeserializeObject<SingleResponse<EmployeLoginDto>>(response);
        resultat = new MessageviewModel<UtilisateurViewModel>();
        resultat.EstErreur= true;
        resultat.Message = requestUri.AbsoluteUri ;
        //((int)httpResponse.StatusCode).ToString()
        //if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        //{
        /* var resultErreur = JsonConvert.DeserializeObject<SingleResponse<EmployeLoginDto>>(response);
           resultat = new MessageviewModel<UtilisateurViewModel>
           {
             Model = null,
             EstErreur = true,
             Messages = new List<MessageErreurs>
             {
                 new MessageErreurs
                 {
                   Code = ((int)httpResponse.StatusCode).ToString(),
                   Libelle = resultErreur.ErrorMessage
                   }
               },
             Message = "Connection reussie"

       };*/

        /* resultat = GestionStatuthttpmessage.ObtenireMessage<TypeClientRequetteViewModel>(
           httpResponse.StatusCode,
           resultErreur.ErrorMessage
           );*/
        //}

      }
      
      return resultat;
    }

    #endregion

    private UtilisateurViewModel FromEntityLogin(SingleResponse<EmployeLoginDto> dto)
    {
      var entity = dto.Model;
      var model = new UtilisateurViewModel()
      {
        Id = entity.Id,
        Nom = entity.Nom,
        SocieteId = entity.SocieteId,
        Email = entity.Email,
        EstCompteActif = entity.EstCompteActif,
         ProfileEmployes = ObetnireProfileEmployes(entity)

      };

      return model;
    }

    private List<ProfileUtilisateurViewModel> ObetnireProfileEmployes(EmployeLoginDto entite)
    {
      var models = (from es in entite.ProfilEmployes
                    select new ProfileUtilisateurViewModel
                    {
                      Id = es.Id,
                      ProfileId = es.ProfileId,
                      EmployeId = es.EmployeId,
                      Profile = new ProfileViewModel
                      {
                        Id = es.Profile.Id,
                        Code = es.Profile.Code,
                        Libelle = es.Profile.Libelle,
                        Droits = ObtenireListeDrois(es.Profile.Droits.ToList())
                      }
                    }).ToList();
      return models;
    }

    private List<DroitsViewModel> ObtenireListeDrois(List<DroitLoginDto> droits)
    {

      var models = (from d in droits
                    select new DroitsViewModel
                    {
                      Id = d.Id,
                      MenuId = d.MenuId,
                      ProfileId = d.ProfileId,
                      Lecture = d.Lecture,
                      Ecriture = d.Ecriture,
                      Suppression = d.Suppression,
                      Impression = d.Impression,
                      ExecutionImport = d.ExecutionImport,
                      ExecutionRapport = d.ExecutionRapport,
                      Menu = new MenuViewModel { Id = d.Menu.Id, Code = d.Menu.Code, Libelle = d.Menu.Libelle }
                    })
                    .ToList();

      return models;

    }

  }

    
}