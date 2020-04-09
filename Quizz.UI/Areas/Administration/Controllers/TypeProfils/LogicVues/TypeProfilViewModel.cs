using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.TypeProfil.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.UI.Services;
using Quizz.Service.DTOS;
using System.IO;

namespace Quizz.UI.Areas.Administration.TypeProfil.LogicVues
{
  public class TypeProfilViewModel: ITypeProfilViewModel
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
      private readonly ITypeProfilTraducteur _traducteur;
      private readonly MySettings _mySettings;
      private readonly string _BaseApi;

    #endregion

    #region Constructeurs
        public TypeProfilViewModel(ITypeProfilTraducteur traducteur,
        IOptions<MySettings> settings)
        {
            _requetteBilder=new HttpRequestBuilder();
            _traducteur=traducteur;
            _mySettings=settings.Value;
            BASE_API=_mySettings.ApiBaseUrl+_mySettings.ApiTypeProfileUrl;
        }
        public TypeProfilViewModel() {
            _traducteur=new TypeProfilTraducteur();
            _mySettings=new MySettings{
                ApiBaseUrl="http://www.ga001.administrationsve.com/",
                ApiTypeProfileUrl="api/v1/TypeProfile/"
            };
            BASE_API=_mySettings.ApiBaseUrl+_mySettings.ApiTypeProfileUrl;
        }
    #endregion

    #region Methodes

    public async Task<MessagePaginationViewModel<List<TypeProfilAfficheViewModel>>> ObtenireListAsync(int societeid, int index=1,int page =10, string libelle = null)
    {
      string URL =null;

        if(string.IsNullOrEmpty(libelle))
        URL = string.Format(GET_ALL, societeid, index, page);
        else
        URL = string.Format(GET_ALL_PRAM, societeid, index, page,libelle);

        var requestUri =new Uri(BASE_API + URL);
         MessagePaginationViewModel<List<TypeProfilAfficheViewModel>> resultat = null;

       var httpResponse =await HttpRequestFactory.Get(requestUri.ToString());
        var readTask = httpResponse.Content.ReadAsStringAsync();
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<PagedResponse<TypeProfilDto>>(response);
           resultat = _traducteur.FromListe(result);
        }else
      {
        if (HttpStatusCode.NotFound == httpResponse.StatusCode ||
        HttpStatusCode.InternalServerError == httpResponse.StatusCode)
        {
          var resultErreur = JsonConvert.DeserializeObject<PagedResponse<TypeProfilDto>>(response);
          resultat = GestionStatuthttpmessage.ObtenirePaginationMessage<List<TypeProfilAfficheViewModel>>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
            );
        }
      }
        return resultat;
    }


    public async  Task<MessageviewModel<TypeProfilRequetteViewModel>> ObtenireParIdAsync(int id)
    {
           var requestUri = new Uri(BASE_API + string.Format(GET_BYID, id));
        MessageviewModel<TypeProfilRequetteViewModel> resultat = null;

        var httpResponse = await HttpRequestFactory.Get(requestUri.AbsoluteUri);
        var readTask = httpResponse.Content.ReadAsStringAsync();
    
        readTask.Wait();
        var response = readTask.Result;
        if (httpResponse.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<SingleResponse<TypeProfilDto>>(response);
          resultat= _traducteur.FromID(result);
        }
       else
        {
          if (HttpStatusCode.NotFound == httpResponse.StatusCode)
          {
              var resultErreur = JsonConvert.DeserializeObject<SingleResponse<TypeProfilDto>>(response);
              resultat = GestionStatuthttpmessage.ObtenireMessage<TypeProfilRequetteViewModel>(
                httpResponse.StatusCode, 
                resultErreur.ErrorMessage
                );
          }
      }
      return resultat;     
      }

    public async Task<MessageviewModel<TypeProfilRequetteViewModel>> CreationAsync(TypeProfilRequetteViewModel model)
    {
       var requestUri = new Uri(BASE_API + POST);
       string url=BASE_API + POST;
      MessageviewModel<TypeProfilRequetteViewModel> resultat = null;
      var httpResponse = await HttpRequestFactory.Post(requestUri.AbsoluteUri , model);
      var readTask = httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        var result = JsonConvert.DeserializeObject<SingleResponse<TypeProfilDto>>(response);
        resultat = _traducteur.FromID(result); 
      }
      else
      {   
           var resultErreur = JsonConvert.DeserializeObject<SingleResponse<TypeProfilDto>>(response);
           resultat = GestionStatuthttpmessage.ObtenireMessage<TypeProfilRequetteViewModel>(
           httpResponse.StatusCode,
           resultErreur.ErrorMessage
          );        
      }
    
      return resultat;
    }

    public async Task<MessageviewModel<TypeProfilRequetteViewModel>> ModificationAsync(TypeProfilRequetteViewModel model)
    {
      var requestUri=new Uri(BASE_API+string.Format(PUT,model.Id));
      MessageviewModel<TypeProfilRequetteViewModel> resultat=null;
      var httpResponse=await HttpRequestFactory.Put(requestUri.AbsoluteUri,model);
      var readTask=httpResponse.Content.ReadAsStringAsync();

      readTask.Wait();
      var response=readTask.Result;
      if(httpResponse.IsSuccessStatusCode)
      {
        var result=JsonConvert.DeserializeObject<SingleResponse<TypeProfilDto>>(response);
        resultat=_traducteur.FromID(result);
      }
      else
      {
        var resultErreur=JsonConvert.DeserializeObject<SingleResponse<TypeProfilDto>>(response);
        resultat=GestionStatuthttpmessage.ObtenireMessage<TypeProfilRequetteViewModel>(
          httpResponse.StatusCode,
          resultErreur.ErrorMessage
        );
      }
      return resultat;
    }

    public async Task<MessageviewModel<TypeProfilRequetteViewModel>> SuppressionAsync(int Id)
    {
        var requestUri=new Uri(BASE_API+string.Format(DELETE,Id));
        MessageviewModel<TypeProfilRequetteViewModel> resultat=null;
        var httpResponse=await HttpRequestFactory.Delete(requestUri.AbsoluteUri);
        var readTask=httpResponse.Content.ReadAsStringAsync();

        readTask.Wait();
        var response=readTask.Result;
        if(httpResponse.IsSuccessStatusCode)
        {
          var resultErreur=JsonConvert.DeserializeObject<SingleResponse<TypeProfilDto>>(response);
          resultat=GestionStatuthttpmessage.ObtenireMessage<TypeProfilRequetteViewModel>(
            httpResponse.StatusCode,
            resultErreur.ErrorMessage
          );
        }
        return resultat;
    }
    #endregion

  }
}
