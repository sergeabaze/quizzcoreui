using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.UI.Services;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.LogicVues
{
  public class SocieteViewModel: ISocieteViewModel
  {
    #region Proprietes
      private Uri BaseEndpoint { get; set; }
      private  string BASE_API ;
      private const string GET_ALL = "rechercher/{0}/{1}/{2}";
      private const string GET_ALL_PRAM = "rechercher/{0}/{1}/{2}?libelle={3}";
      private const string GET_BYID = "{0}";
      private const string POST = "creation";
      private const string PUT = "misejour/{0}";
      private const string DELETE = "suppression/{0}";
      private readonly HttpRequestBuilder _requetteBilder;
      private readonly ISocieteTraducteur _traducteur;
      private readonly MySettings _mySettings;
      private readonly string _BaseApi;

    #endregion

    #region Constructeurs
      public SocieteViewModel(ISocieteTraducteur traducteur,
      IOptions<MySettings> settings)
      {
        _requetteBilder = new HttpRequestBuilder();
        _traducteur = traducteur;
        _mySettings = settings.Value;
         BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiSocieteUrl;
       }

        public SocieteViewModel(){
            _traducteur = new SocieteTraducteur();
            _mySettings = new MySettings()
              {
                ApiBaseUrl = "http://localhost:60/",
                ApiSocieteUrl = "api/v1/Societe/"
                };
            BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiSocieteUrl;
        }

    #endregion
    #region Methode Publics

      public async Task<MessagePaginationViewModel<List<SocieteAfficheViewModel>>> ObtenireListAsync(int societeid, int index = 1, int page = 10,string libelle = null)
      {
        string URL =null;

        if(string.IsNullOrEmpty(libelle))
        URL = string.Format(GET_ALL, societeid, index, page);
        else
        URL = string.Format(GET_ALL_PRAM, societeid, index, page,libelle);

        var requestUri =new Uri(BASE_API + URL);
         MessagePaginationViewModel<List<SocieteAfficheViewModel>> resultat = null;

       var httpResponse =await HttpRequestFactory.Get(requestUri.ToString());
        var readTask = httpResponse.Content.ReadAsStringAsync();
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<PagedResponse<SocieteDto>>(response);
           resultat = _traducteur.FromListe(result);
        }else
      {
        if (HttpStatusCode.NotFound == httpResponse.StatusCode ||
        HttpStatusCode.InternalServerError == httpResponse.StatusCode)
        {
          var resultErreur = JsonConvert.DeserializeObject<PagedResponse<SocieteDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenirePaginationMessage<List<SocieteAfficheViewModel>>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        }
      }
        return resultat;
      }

      public async Task<MessageviewModel<SocieteRequetteViewModel>> ObtenireParIdAsync(int id)
      {

        var requestUri = new Uri(BASE_API + string.Format(GET_BYID, id));
        MessageviewModel<SocieteRequetteViewModel> resultat = null;

        var httpResponse = await HttpRequestFactory.Get(requestUri.AbsoluteUri);
        var readTask = httpResponse.Content.ReadAsStringAsync();
    
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
          resultat= _traducteur.FromID(result);
        }
       else
        {

            if (HttpStatusCode.NotFound == httpResponse.StatusCode)
            {
               var resultErreur = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
               resultat = GestionStatuthttpmessage.ObtenireMessage<SocieteRequetteViewModel>(
                 httpResponse.StatusCode, 
                 resultErreur.ErrorMessage
                 );
            }
      }
      return resultat;     
      }

    public async Task<MessageviewModel<SocieteRequetteViewModel>> CreationAsync(SocieteRequetteViewModel model)
    {
      var requestUri = new Uri(BASE_API + POST);
      MessageviewModel<SocieteRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Post(requestUri.AbsoluteUri , model);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        //if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        //{
          var resultErreur = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenireMessage<SocieteRequetteViewModel>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        //}       
      }
      
      return resultat;
    }

    public async Task<MessageviewModel<SocieteRequetteViewModel>> ModificationAsync(SocieteRequetteViewModel model)
    {
      var requestUri = new Uri(BASE_API + string.Format(PUT,model.Id));
      MessageviewModel<SocieteRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Put(requestUri.AbsoluteUri, model);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
        resultat = GestionStatuthttpmessage.ObtenireMessage<SocieteRequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );

      }

      return resultat;
    }

    public async Task<MessageviewModel<SocieteRequetteViewModel>> SuppressionAsync(int Id)
    {
      var requestUri = new Uri(BASE_API + string.Format(DELETE, Id) );
      MessageviewModel<SocieteRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Delete(requestUri.AbsoluteUri);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        //if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        //{
        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<SocieteDto>>(response);
        resultat = GestionStatuthttpmessage.ObtenireMessage<SocieteRequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );
        //} 
      } 
      return resultat;
    } 
    #endregion
  }
}