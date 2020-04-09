using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.Profil.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.UI.Services;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Profil.LogicVues
{
  public class ProfilViewModel: IProfilViewModel
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
      private readonly IProfilTraducteur _traducteur;
      private readonly MySettings _mySettings;
      private readonly string _BaseApi;

    #endregion

    #region Constructeurs
      public ProfilViewModel(IProfilTraducteur traducteur,
      IOptions<MySettings> settings)
      {
        _requetteBilder = new HttpRequestBuilder();
        _traducteur = traducteur;
        _mySettings = settings.Value;
         BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiProfilUrl;
       }

        public ProfilViewModel(){
            _traducteur = new ProfilTraducteur();
            _mySettings = new MySettings()
              {
                ApiBaseUrl = "http://www.ga001.administrationsve.com/",
                ApiProfilUrl = "api/v1/Profil/"
              };
            BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiProfilUrl;
        }

    #endregion
    #region Methode Publics

      public async Task<MessagePaginationViewModel<List<ProfilAfficheViewModel>>> ObtenireListAsync(int Profilid, int index = 1, int page = 10,string libelle = null)
      {
        string URL =null;

        if(string.IsNullOrEmpty(libelle))
        URL = string.Format(GET_ALL, Profilid, index, page);
        else
        URL = string.Format(GET_ALL_PRAM, Profilid, index, page,libelle);

        var requestUri =new Uri(BASE_API + URL);
         MessagePaginationViewModel<List<ProfilAfficheViewModel>> resultat = null;

       var httpResponse =await HttpRequestFactory.Get(requestUri.ToString());
        var readTask = httpResponse.Content.ReadAsStringAsync();
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<PagedResponse<ProfilListDto>>(response);
           resultat = _traducteur.FromListe(result);
        }
        else
       {
        if (HttpStatusCode.NotFound == httpResponse.StatusCode ||
        HttpStatusCode.InternalServerError == httpResponse.StatusCode)
        {
          var resultErreur = JsonConvert.DeserializeObject<PagedResponse<ProfilListDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenirePaginationMessage<List<ProfilAfficheViewModel>>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        }
      }
        return resultat;
      }

      public async Task<MessageviewModel<ProfilRequetteViewModel>> ObtenireParIdAsync(int id)
      {

        var requestUri = new Uri(BASE_API + string.Format(GET_BYID, id));
        MessageviewModel<ProfilRequetteViewModel> resultat = null;

        var httpResponse = await HttpRequestFactory.Get(requestUri.AbsoluteUri);
        var readTask = httpResponse.Content.ReadAsStringAsync();
    
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
          resultat= _traducteur.FromID(result);
        }
       else
        {

            if (HttpStatusCode.NotFound == httpResponse.StatusCode)
            {
               var resultErreur = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
               resultat = GestionStatuthttpmessage.ObtenireMessage<ProfilRequetteViewModel>(
                 httpResponse.StatusCode, 
                 resultErreur.ErrorMessage
                 );
            }
      }
      return resultat;     
      }

    public async Task<MessageviewModel<ProfilRequetteViewModel>> CreationAsync(ProfilRequetteViewModel model)
    {
      var requestUri = new Uri(BASE_API + POST);
      MessageviewModel<ProfilRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Post(requestUri.AbsoluteUri , model);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        //if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        //{
          var resultErreur = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenireMessage<ProfilRequetteViewModel>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        //}       
      }
      
      return resultat;
    }

    public async Task<MessageviewModel<ProfilRequetteViewModel>> ModificationAsync(ProfilRequetteViewModel model)
    {
      var requestUri = new Uri(BASE_API + string.Format(PUT,model.Id));
      MessageviewModel<ProfilRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Put(requestUri.AbsoluteUri, model);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
        resultat = GestionStatuthttpmessage.ObtenireMessage<ProfilRequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );

      }

      return resultat;
    }

    public async Task<MessageviewModel<ProfilRequetteViewModel>> SuppressionAsync(int Id)
    {
      var requestUri = new Uri(BASE_API + string.Format(DELETE, Id) );
      MessageviewModel<ProfilRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Delete(requestUri.AbsoluteUri);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        //if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        //{
        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<ProfilDto>>(response);
        resultat = GestionStatuthttpmessage.ObtenireMessage<ProfilRequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );
        //} 
      }
      System.IO.File.WriteAllText(@"D:\\echec.txt", resultat.ToString());

      return resultat;
    }

    public Task<MessageviewModel<ProfilRequetteViewModel>> SuppressionAsync(ProfilRequetteViewModel model)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}