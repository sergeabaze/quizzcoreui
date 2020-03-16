using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quizz.Service;
using Quizz.Service.DTOS;
using Xunit;

namespace Quizz.service.Tests
{
  public class TypeClientServiceTest
  {
    private readonly HttpRequestBuilder _http;
    private readonly ITypeClientService _http2;

    public TypeClientServiceTest(){
      _http = new HttpRequestBuilder();
      //Uri BaseEndpoint
      _http2 = new TypeClientService(new Uri("http://localhost:60"));
    }

    [Fact]
    public async Task ObtenireListeHttp_Devrait_retournerListe()
    {
      //arrange
      var requestUri = "http://localhost:60/api/v1/TypeClient/rechercher1/10";
      ListResponse<TypeClientAffiche> resultat = null;

      //act
        var httpResponse = await HttpRequestBuilder.HttpRequestFactory.Get(requestUri);
        var attendu = 3;
      //var outputModel = response.ContentAsType<IListResponse<TypeClientList>>();
      var readTask = httpResponse.Content.ReadAsStringAsync();
      readTask.Wait();
      var response = readTask.Result;
      if( httpResponse.IsSuccessStatusCode ){
        resultat = JsonConvert.DeserializeObject<ListResponse<TypeClientAffiche>>(response);
      }
      
      //assert
      Assert.True(HttpStatusCode.OK == httpResponse.StatusCode,"Uns statut est manquant");
      Assert.False(resultat.DidError);
      Assert.Equal(attendu, resultat.Model.ToList().Count);
    }

    [Fact]
    public async Task ObtenireparID_Http_Devrait_retournerTypeClient()
    {
      //arrange
      var Id = 1;
      var requestUri = $"http://localhost:60/api/v1/TypeClient/{Id}";
      SingleResponse<TypeClientAffiche> resultat = null;

      //act
      var httpResponse = await HttpRequestBuilder.HttpRequestFactory.Get(requestUri);
      
      //var outputModel = response.ContentAsType<IListResponse<TypeClientList>>();
      var readTask = httpResponse.Content.ReadAsStringAsync();
      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        resultat = JsonConvert.DeserializeObject<SingleResponse<TypeClientAffiche>>(response);
      }

      //assert
      Assert.True(HttpStatusCode.OK == httpResponse.StatusCode, "Uns statut est manquant");
      Assert.False(resultat.DidError);
      Assert.NotNull(resultat.Model);
      Assert.Equal(Id,resultat.Model.Id);
     
    }

   
    [Fact]
    public async Task ObtenireparID_Http_Devrait_retournerTypeClientNotFound()
    {
      //arrange
      var Id = 10;
      var requestUri = $"http://localhost:60/api/v1/TypeClient/{Id}";
      SingleResponse<TypeClientAffiche> resultat = null;
      //act
      var httpResponse = await HttpRequestBuilder.HttpRequestFactory.Get(requestUri);

      var readTask = httpResponse.Content.ReadAsStringAsync();
      readTask.Wait();
      var response = readTask.Result;
      if (httpResponse.IsSuccessStatusCode)
      {
        resultat = JsonConvert.DeserializeObject<SingleResponse<TypeClientAffiche>>(response);
      }else
      {
        resultat = new SingleResponse<TypeClientAffiche>();
        resultat.DidError =true;
      }
      //assert
      Assert.True(HttpStatusCode.NotFound == httpResponse.StatusCode, "Uns statut est manquant");
      Assert.True(resultat.DidError);
    }
  }
}
