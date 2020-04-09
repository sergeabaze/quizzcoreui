using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json; 
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.UI.Services;
using Quizz.Service.DTOS;
using Quizz.UI.Areas.Administration.TypeEmployer.Traducteur;


namespace Quizz.UI.Areas.Administration.TypeEmployer.LogicVues
{
  public class TypeEmployerViewModel: ITypeEmployerViewModel
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
      private readonly ITypeEmployerTraducteur _traducteur;
      private readonly MySettings _mySettings;
      private readonly string _BaseApi;

    #endregion

    #region Constructeurs
      public TypeEmployerViewModel(ITypeEmployerTraducteur traducteur,
      IOptions<MySettings> settings)
      {
        _requetteBilder = new HttpRequestBuilder();
        _traducteur = traducteur;
        _mySettings = settings.Value;
         BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiTypeEmployeUrl;
       }

        public TypeEmployerViewModel(){
            _traducteur = new TypeEmployerTraducteur();
            _mySettings = new MySettings()
              {
                ApiBaseUrl = "http://www.ga001.administrationsve.com/",
              ApiTypeEmployeUrl = "api/v1/TypeEmployer/"
                };
            BASE_API = _mySettings.ApiBaseUrl + _mySettings.ApiTypeEmployeUrl;
        }

    #endregion
    
    #region Methodes
    #endregion
  }
}