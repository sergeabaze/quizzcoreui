using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Quizz.UI;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.TypeClient.LogicVues;
using Quizz.UI.Areas.Administration.TypeClient.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Xunit;
namespace Quizz.ui.Tests.Typeclient
{
  public class TypeClientViewModel_HttpTest
  {
    Fixture _fixture;
    private  ITypeClientViewModel _viewModel;
  
    public TypeClientViewModel_HttpTest()
    {
    
    //  _viewModel = new TypeClientViewModel();
      _fixture = new Fixture();
      _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
       .ForEach(b => _fixture.Behaviors.Remove(b));
      _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
     
    }

    [Fact]
    public async Task ObtenirePar_IDAsync_http_Doit_retournerTypeClient()
    {
      //arrange
        _viewModel = new TypeClientViewModel();
        int Id = 1;

      //act
       var response =await _viewModel.ObtenireParIdAsync(Id) ;

      //assert
         Assert.NotNull(response);
         Assert.NotNull(response.Model);
         Assert.False(response.EstErreur, "pas derreur un false attendu");
         Assert.Equal(Id, response.Model.Id);
    }

    [Fact]
    public async Task ObtenirePar_IdAsync_Echec_ID_Inexistant_http_Doit_retourner_NotFound_404()
    {
      //arrange
      _viewModel = new TypeClientViewModel();
      int Id = 1000;

      //act
      var response = await _viewModel.ObtenireParIdAsync(Id);

      //assert

      Assert.NotNull(response);
      Assert.Null(response.Model);
      Assert.True(response.EstErreur);
      Assert.True(response.Messages.Count >0);
      Assert.True(response.Messages.Any(m => m.Code == "404"), "Un code Notfound (404) Attendu pour cette erreu");
     
    }

    [Fact]
    public async Task RechercherAsync_http_Doit_retourner_ListeTypeclient()
    {
      //arrange
      _viewModel = new TypeClientViewModel();
      int societeid = 1;

      //act
      var response = await _viewModel.ObtenireListAsync(societeid);

      //assert
      Assert.NotNull(response);
      Assert.NotNull(response.Model);
      Assert.False(response.EstErreur);
      Assert.True(response.Model.Count >0,"uneliste des donnes est attendu");
      Assert.True(response.PageSize > 0, "une pagesize attendu");
      Assert.True(response.PageCount > 0, "un nombre de page attendu");
      Assert.True(response.ItemCount > 0, "uneliste des donnes est attendu");
    }

    [Fact]
    public async Task RechercherAsync_http_Par_Libelle_Doit_retourner_ListeTypeclient()
    {
      //arrange
      _viewModel = new TypeClientViewModel();
      int societeid = 1;
      string libelle = "societe";

      //act
      var response = await _viewModel.ObtenireListAsync(societeid,10,1,libelle);

      //assert
      Assert.NotNull(response);
      Assert.NotNull(response.Model);
      Assert.False(response.EstErreur);
      Assert.True(response.Model.Count == 1, "une des donnes est attendu --"+response.Model.Count.ToString());
    }

    [Fact]
    public async Task RechercherAsync_http_Par_Libelle_Echec_Doit_retourner_Erreur_500()
    {
      //arrange
      _viewModel = new TypeClientViewModel();
      int societeid = 1;
      string libelle = "societeddddd";

      //act
      var response = await _viewModel.ObtenireListAsync(societeid, 10, 1, libelle);

      //assert
      Assert.NotNull(response);
      Assert.Null(response.Model);
      Assert.True(response.EstErreur);
      Assert.True(response.Messages.Any(m => m.Code == "500"), "Un code Internal error (500) Attendu pour cette erreu");
    }


    [Fact]
    public async Task CreationAsync_Avec_Success_doit_retourner_200()
    {
      //arrange
       var typeclient = new TypeClientRequetteViewModel { Id =0, Code ="hack1", Libelle ="hackeur11"  };
      //act

      _viewModel = new TypeClientViewModel();
      var requette = await _viewModel.CreationAsync(typeclient);

      //assert
       Assert.NotNull(requette);
       Assert.NotNull(requette.Model);
       Assert.False(requette.EstErreur);
    }


    [Fact]
    public async Task CreationAsync_Objet_ExisteDeja_BadRequest_400()
    {
      //arrange
      var typeclient = new TypeClientRequetteViewModel { Id = 0, Code = "demalo", Libelle = "demalo" };
      //act

      _viewModel = new TypeClientViewModel();
      var requette = await _viewModel.CreationAsync(typeclient);

      //assert
      Assert.NotNull(requette);
      Assert.True(requette.EstErreur, "une message dereur est attendu");
      Assert.True(requette.Messages.Any(m=>m.Code == "400"), "une message dereur est attendu");
    }

    [Fact]
    public async Task MisejourAsync_Avec_Success_doit_retourner_200()
    {
      //arrange
      var typeclient = new TypeClientRequetteViewModel { Id = 4, Code = "zack", Libelle = "zackeurdesii12" };
      //act

      _viewModel = new TypeClientViewModel();
      var requette = await _viewModel.ModificationAsync(typeclient);

      //assert
      Assert.NotNull(requette);
      Assert.NotNull(requette.Model);
      Assert.False(requette.EstErreur);
      Assert.Equal(requette.Model.Id,4);
    }

    [Fact]
    public async Task SuppressionAsync_Avec_Success_doit_retourner_200()
    {
      //arrange
      var typeclientid =4;
      //act

      _viewModel = new TypeClientViewModel();
      var requette = await _viewModel.SuppressionAsync(typeclientid);

      //assert
      Assert.NotNull(requette);
      Assert.False(requette.EstErreur);
    }

    [Fact]
    public async Task SuppressionAsync_Avec_Echec_doit_retourner_NotFound_404()
    {
      //arrange
      var typeclientid = 7000;
      //act

      _viewModel = new TypeClientViewModel();
      var requette = await _viewModel.SuppressionAsync(typeclientid);

      //assert
      Assert.NotNull(requette);
      Assert.Null(requette.Model);
      Assert.True(requette.EstErreur);
      Assert.True(requette.Messages.Any(m => m.Code == "404"), "Not found(404) attendudereur ");
    }
  }

}