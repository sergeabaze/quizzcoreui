using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Quizz.UI.Areas.Administration.LogicVues;
using Quizz.UI.Areas.Administration.Models;
using Xunit;
namespace Quizz.ui.Tests.Employe
{
  public class EmployeViewModelHttp_Test
  {
    Fixture _fixture;
    private IEmployeViewModel _viewModel;

    public EmployeViewModelHttp_Test()
    {
    }

    [Fact]
    public async Task ObtenirePar_IDAsync_http_Doit_retourner_Employe()
    {
      //arrange
      _viewModel = new EmployeViewModel();
      int Id = 1;

      //act
      var de = await Task.FromResult(new { id = Id });
      var response =await _viewModel.ObtenireParIdAsync(Id) ;

      //assert
        Assert.NotNull(response);
        Assert.NotNull(response.Model);
        Assert.False(response.EstErreur, "pas derreur un false attendu");
        Assert.Equal(Id, response.Model.Id);
    }

    [Fact]
    public async Task RechercherAsync_http_Par_Societe_Doit_retourner_Employes()
    {
      //arrange
      _viewModel = new EmployeViewModel();
      int societeid = 1;
     //string libelle = "societe";
      //var asyntask = await Task.FromResult(new { id = societeid, libelle = libelle });
      //act
       var response = await _viewModel.ObtenireListAsync(societeid, 1, 10);

      //assert
       Assert.NotNull(response);
        Assert.NotNull(response.Model);
       Assert.False(response.EstErreur);
      Assert.True(response.Model.Count > 0, "une des donnes est attendu --"+response.Model.Count.ToString());
    }

    [Fact]
    public async Task RechercherAsync_http_Par_Societe_nom_Doit_retourner_Employes()
    {
      //arrange
      _viewModel = new EmployeViewModel();
      int societeid = 1;
      //string libelle = "societe";
      //var asyntask = await Task.FromResult(new { id = societeid, libelle = libelle });
      //act
      var response = await _viewModel.ObtenireListAsync(societeid, 1, 10,"mebenga","15f");

      //assert
      Assert.NotNull(response);
      Assert.NotNull(response.Model);
      Assert.False(response.EstErreur);
      Assert.True(response.Model.Count > 0, "une des donnes est attendu --" + response.Model.Count.ToString());
    }

    [Fact]
    public async Task CreationAsync_Avec_Success_doit_retourner_200()
    {
      //arrange
      var employe = new EmployeCreationViewModel
      {
        SocieteId = 1,
        TypeEmployeId = 1,
        Nom = "teste",
        Prenom = "teste",
        Matricule = "de45201g",
        MotPasse = "desissgg",
        Email = "teste@yahoo.fr",
        Telephone1 = "55555555555",
        Telephone2 = "75555555555",
        EstCompteSupprimer = false,
        EstCompteActif = true,
        CreePar = "lola.admin",
      };
     // var asyntask = await Task.FromResult(employe);
      //act

      _viewModel = new EmployeViewModel();
      var requette = await _viewModel.CreationAsync(employe);

      //assert
       Assert.NotNull(requette);
       Assert.False(requette.EstErreur);
     //  Assert.NotNull(requette.Model);
      
    }

    [Fact]
    public async Task ModificationAsync_Avec_Success_doit_retourner_200()
    {
      //arrange
      var employe = new EmployeEditionViewModel
      {
         Id =5,
        SocieteId = 1,
        TypeEmployeId = 1,
        Nom = "lambda",
        Prenom = "teste",
        Matricule = "de45201g",
        MotPasse = "desissgg",
        Email = "teste@yahoo.fr",
        Telephone1 = "22245212",
        Telephone2 = "333333333",
        EstCompteSupprimer = true,
        EstCompteActif = true,
        MiseJourPar = "lola.admin",
      };
      // var asyntask = await Task.FromResult(employe);
      //act

      _viewModel = new EmployeViewModel();
      var requette = await _viewModel.ModificationAsync(employe);

      //assert
      Assert.NotNull(requette);
      Assert.False(requette.EstErreur);
      //  Assert.NotNull(requette.Model);

    }

    [Fact]
    public async Task SuppressionAsync_Avec_Success_doit_retourner_200()
    {
      int id = 3;

       _viewModel = new EmployeViewModel();
       var requette = await _viewModel.SuppressionAsync(id);
      //assert
      Assert.NotNull(requette);

    }
  }
  }