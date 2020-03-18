using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.TypeClient.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Areas.Administration.TypeClient.LogicVues
{
  public class TypeClientViewModel: ITypeClientViewModel
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
    private readonly ITypeClientTraducteur _traducteur;
    private readonly MySettings _mySettings;
    private readonly string _BaseApi;

    #endregion

    #region Constructeurs
      public TypeClientViewModel(ITypeClientTraducteur traducteur,
      IOptions<MySettings> settings)
      {
        _requetteBilder = new HttpRequestBuilder();
        _traducteur = traducteur;
        _mySettings = settings.Value;
         BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiTypeclientUrl;
       }

        public TypeClientViewModel(){
            _traducteur = new TypeClientTraducteur();
            _mySettings = new MySettings()
              {
                ApiBaseUrl = "http://localhost:60/",
                ApiTypeclientUrl = "api/v1/TypeClient/"
                };
            BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiTypeclientUrl;
        }

    #endregion
    #region Methode Publics

      public async Task<MessagePaginationViewModel<List<TypeClientAfficheViewModel>>> ObtenireListAsync(int societeid, int index = 1, int page = 10,string libelle = null)
      {
        string URL =null;

        if(string.IsNullOrEmpty(libelle))
        URL = string.Format(GET_ALL, societeid, index, page);
        else
        URL = string.Format(GET_ALL_PRAM, societeid, index, page,libelle);

        var requestUri =new Uri(BASE_API + URL);
         MessagePaginationViewModel<List<TypeClientAfficheViewModel>> resultat = null;

       var httpResponse =await HttpRequestFactory.Get(requestUri.ToString());
        var readTask = httpResponse.Content.ReadAsStringAsync();
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<PagedResponse<TypeClientDto>>(response);
           resultat = _traducteur.FromListe(result);
        }else
      {
        if (HttpStatusCode.NotFound == httpResponse.StatusCode ||
        HttpStatusCode.InternalServerError == httpResponse.StatusCode)
        {
          var resultErreur = JsonConvert.DeserializeObject<PagedResponse<TypeClientDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenirePaginationMessage<List<TypeClientAfficheViewModel>>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        }
      }
        return resultat;
      }

      public async Task<MessageviewModel<TypeClientRequetteViewModel>> ObtenireParIdAsync(int id)
      {

        var requestUri = new Uri(BASE_API + string.Format(GET_BYID, id));
        MessageviewModel<TypeClientRequetteViewModel> resultat = null;

        var httpResponse = await HttpRequestFactory.Get(requestUri.AbsoluteUri);
        var readTask = httpResponse.Content.ReadAsStringAsync();
    
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
          resultat= _traducteur.FromID(result);
        }
       else
        {

            if (HttpStatusCode.NotFound == httpResponse.StatusCode)
            {
               var resultErreur = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
               resultat = GestionStatuthttpmessage.ObtenireMessage<TypeClientRequetteViewModel>(
                 httpResponse.StatusCode, 
                 resultErreur.ErrorMessage
                 );
            }
      }
      return resultat;     
      }

    public async Task<MessageviewModel<TypeClientRequetteViewModel>> CreationAsync(TypeClientRequetteViewModel model)
    {
      var requestUri = new Uri(BASE_API + POST);
      MessageviewModel<TypeClientRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Post(requestUri.AbsoluteUri , model);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        //if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        //{
          var resultErreur = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenireMessage<TypeClientRequetteViewModel>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        //}
       
      }
      
      return resultat;
    }

    public async Task<MessageviewModel<TypeClientRequetteViewModel>> ModificationAsync(TypeClientRequetteViewModel model)
    {
      var requestUri = new Uri(BASE_API + string.Format(PUT,model.Id));
      MessageviewModel<TypeClientRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Put(requestUri.AbsoluteUri, model);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
        resultat = GestionStatuthttpmessage.ObtenireMessage<TypeClientRequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );

      }

      return resultat;
    }

    public async Task<MessageviewModel<TypeClientRequetteViewModel>> SuppressionAsync(int Id)
    {
      var requestUri = new Uri(BASE_API + string.Format(DELETE, Id) );
      MessageviewModel<TypeClientRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Delete(requestUri.AbsoluteUri);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
        resultat = _traducteur.FromID(result);
      }
      else
      {
        //if (HttpStatusCode.NotFound == httpResponse.StatusCode)
        //{
        var resultErreur = JsonConvert.DeserializeObject<SingleResponse<TypeClientDto>>(response);
        resultat = GestionStatuthttpmessage.ObtenireMessage<TypeClientRequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
          );
        //}

      }

      return resultat;
    }

    public Task<MessageviewModel<TypeClientRequetteViewModel>> SuppressionAsync(TypeClientRequetteViewModel model)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}