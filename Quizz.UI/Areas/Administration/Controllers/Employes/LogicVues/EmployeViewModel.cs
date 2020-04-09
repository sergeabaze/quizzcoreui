using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quizz.Service.DTOS;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.Traducteur;
using Quizz.UI.Communs;
using Quizz.UI.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Areas.Administration.LogicVues
{
  public class EmployeViewModel: IEmployeViewModel
  {
    #region Proprietes
    
    private Uri BaseEndpoint { get; set; }
    private string BASE_API;
    private const string GET_ALL = "rechercher/{0}/{1}/{2}";
    private const string GET_ALL_PRAM = "rechercher/{0}/{1}/{2}?nom={3}&matricule={4}&telephone={5}&email={6}";
    private const string GET_BYID = "{0}";
    private const string POST = "creation";
    private const string PUT = "misejour/{0}";
    private const string DELETE = "suppression/{0}";
    private readonly IHttpCustomClientFactory _htpclient;
    private readonly IEmployeTraducteur _traducteur;
    private readonly MySettings _mySettings;


    #endregion

    #region Constructeurs


    public EmployeViewModel(IEmployeTraducteur traducteur,
      IOptions<MySettings> settings, IHttpCustomClientFactory htpclient)
      {
       _htpclient = htpclient;
      _traducteur = traducteur;
      _mySettings = settings.Value;
      BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiEmployeUrl;
     }

  public EmployeViewModel() { 
      _traducteur = new EmployeTraducteur();
      _htpclient = new HttpCustomClientFactory();
      _mySettings = new MySettings()
      {
        ApiBaseUrl = "http://localhost:60/",
        ApiEmployeUrl = "api/v1/Employe/"
                  };
      BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiEmployeUrl;
    }

    #endregion

    public async Task<MessagePaginationViewModel<List<EmployeAfficheViewModel>>> ObtenireListAsync(int societeid, int index = 1, int pageCount = 10, string nom = null, string matricule = null, string telephone = null, string email = null)
    {
      Uri requestUri = null;
      if(string.IsNullOrEmpty(nom) && string.IsNullOrEmpty(matricule) && string.IsNullOrEmpty(telephone) && string.IsNullOrEmpty(email))
       requestUri = new Uri(BASE_API + string.Format(GET_ALL, societeid, pageCount, index ));
       else
        requestUri = new Uri(BASE_API + string.Format(GET_ALL_PRAM, societeid, pageCount, index,nom,matricule,telephone,email));
            
       
      MessagePaginationViewModel<List<EmployeAfficheViewModel>> resultat = null;

      var httpResponse = await _htpclient.Get(requestUri.AbsoluteUri);
    //  httpResponse.EnsureSuccessStatusCode();
     // var content = await httpResponse.Content.ReadAsStringAsync();
     // var resultatTeste = JsonConvert.DeserializeObject<PagedResponse<EmployeListeDto>>(content);

      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<PagedResponse<EmployeListeDto>>(response);
        resultat = _traducteur.FromListe(result);
      }
      else
      {

        if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        {
          var resultErreur = JsonConvert.DeserializeObject<PagedResponse<EmployeListeDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenirePaginationMessage<List<EmployeAfficheViewModel>>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        }
      }
      return resultat;
    }

    public async Task<MessageviewModel<EmployerequetteViewModel>> ObtenireParIdAsync(int id)
    {
      var requestUri = new Uri(BASE_API + string.Format(GET_BYID, id));
      MessageviewModel<EmployerequetteViewModel> resultat = null;

      var httpResponse = await _htpclient.Get(requestUri.AbsoluteUri);
     
     var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
     if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {

        if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        {
          var resultErreur = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenireMessage<EmployerequetteViewModel>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        }
      }
      return resultat;
    }

    public async Task<MessageviewModel<EmployerequetteViewModel>> CreationAsync(EmployeCreationViewModel model)
    {
      var requestUri = new Uri(BASE_API + POST);
      MessageviewModel<EmployerequetteViewModel> resultat = null;
      var entite = _traducteur.TraduitVers(model);
      var httpResponse = await _htpclient.Post(requestUri.AbsoluteUri, entite);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        
        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);
       
        resultat = GestionStatuthttpmessage.ObtenireMessage<EmployerequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );
        resultat.Message =requestUri.AbsoluteUri + ((int)(httpResponse.StatusCode)).ToString()+ "--" +resultErreur.ErrorMessage;
        //}

      }

      return resultat;
      
    }

    public async Task<MessageviewModel<EmployerequetteViewModel>> ModificationAsync(EmployeEditionViewModel model)
    {
      var requestUri = new Uri(BASE_API + string.Format(PUT,model.Id));
      MessageviewModel<EmployerequetteViewModel> resultat = null;
      var entite = _traducteur.TraduitEditVers(model);
      var httpResponse = await _htpclient.Put(requestUri.AbsoluteUri, entite);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {

        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);

        resultat = GestionStatuthttpmessage.ObtenireMessage<EmployerequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );
        resultat.Message = requestUri.AbsoluteUri + ((int)(httpResponse.StatusCode)).ToString() + "--" + resultErreur.ErrorMessage;
        //}

      }

      return resultat;
    }

    public async Task<MessageviewModel<EmployerequetteViewModel>> SuppressionAsync(int Id)
    {
      var requestUri = new Uri(BASE_API + string.Format(DELETE, Id));

      MessageviewModel<EmployerequetteViewModel> resultat = null;
      var httpResponse = await _htpclient.Delete(requestUri.AbsoluteUri);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);
        resultat = new MessageviewModel<EmployerequetteViewModel> { 
          EstErreur = false
        };
      }
      else
      {

        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<EmployeDto>>(response);

        resultat = GestionStatuthttpmessage.ObtenireMessage<EmployerequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );
        resultat.Message = requestUri.AbsoluteUri + ((int)(httpResponse.StatusCode)).ToString() + "--" + resultErreur.ErrorMessage;
        //}

      }

      return resultat;
    }

   
  }

}