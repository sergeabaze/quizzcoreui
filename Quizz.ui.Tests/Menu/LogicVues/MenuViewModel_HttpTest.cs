using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Quizz.UI;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.Menu.LogicVues;
using Quizz.UI.Areas.Administration.Menu.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Xunit;
namespace Quizz.ui.Tests.Menu
{
  public class MenuViewModel_HttpTest
  {
      Fixture _fixture;
      private IMenuViewModel _viewModel;

      public MenuViewModel_HttpTest()
      {
          _fixture=new Fixture();
      }

     [Fact]
     public async Task RechercheAsync_Menu_Doit_Retourner_Vrai()
     {
         //Arrange
         _viewModel=new MenuViewModel();
         int societeId=1;
         //Act
         var result=await _viewModel.ObtenireListAsync(societeId);
         //Assert
         Assert.NotNull(result);
         Assert.NotNull(result.Model);
         Assert.False(result.EstErreur);
         Assert.True(result.Model.Count>0);
         Assert.True(result.PageSize>0);
         Assert.True(result.PageCount>0);
     }
 
      [Fact]
      public async Task Test_ObtenirParID_Retourne_Vrai()
      {
          //Arrange
          int id=2;
          _viewModel=new MenuViewModel();
          //Act
          var result=await _viewModel.ObtenireParIdAsync(id);
          //Assert
          Assert.NotNull(result);
          Assert.NotNull(result.Model);
          Assert.Equal(id,result.Model.Id);

      } 

      [Fact]
      public async Task Test_ObtenirParID_Echec_Inexistant()
      {
          //Arrange
          int id=220;
          _viewModel=new MenuViewModel();
          //Act
          var result=await _viewModel.ObtenireParIdAsync(id);
          //Assert
          Assert.NotNull(result);
          Assert.Null(result.Model);
          Assert.Null(result.Message);
          Assert.True(result.EstErreur);

      }
 
      [Fact]
      public async Task CreationAsync_Avec_Succes_doit_retourner_200()
      {
          //Arrange
          var Menu= new MenuRequetteViewModel{Id=0,Code="MCV",Libelle="Marketing"};
          //Act
         _viewModel=new MenuViewModel();
          var result= await _viewModel.CreationAsync(Menu);
          //Assert
          Assert.NotNull(result);
          Assert.NotNull(result.Model);
          Assert.False(result.EstErreur);
      } 

      [Fact]
      public async Task CreationAsync_Avec_Echec_Doublons()
      {
           //Arrange
         var Menu=new MenuRequetteViewModel{Id=0,Code="MCV",Libelle="Marketing"};
          //Act
         _viewModel=new MenuViewModel();
          var result= await _viewModel.CreationAsync(Menu);
          //Assert 
          Assert.Equal(result.Messages[0].Libelle,"Creation impossible Cet Objet exite deja dans la base");
          Assert.False(result.EstErreur);
      }
    
      [Fact]
      public async Task MiseAJour_Menu_Retourne_200()
      {
             //Arrange
         var Menu=new MenuRequetteViewModel{Id=5,Code="Sakoi",Libelle="Sde"};
          //Act
         _viewModel=new MenuViewModel();
          var result= await _viewModel.ModificationAsync(Menu);
          //Assert 
          Assert.NotNull(result);
          // Assert.Equal(result.Messages[0].Libelle,"Creation impossible Cet Objet exite deja dans la base");
         // Assert.True(result.EstErreur);
      }

        [Fact]
        public async Task MiseAJour_Menu_Retourne_400()
        {
                //Arrange
            var Menu=new MenuRequetteViewModel{Id=506,Code="Skeco",Libelle="se"};
            //Act
            _viewModel=new MenuViewModel();
            var result= await _viewModel.ModificationAsync(Menu);
            //Assert 
            Assert.NotNull(result);
            Assert.Null(result.Message);
            Assert.Null(result.Model);
            Assert.True(result.EstErreur);
        }
    
        [Fact]
        public async Task SuppressionAsync_Avec_Succes()
        {
            //Arrange
            var MenuId=6;
            //Act
            _viewModel=new MenuViewModel();
            var result=await _viewModel.SuppressionAsync(MenuId);
            //Assert
            Assert.Equal("Suppression de lobjet",result.Messages[0].Libelle);
        }  
        [Fact]
        public async Task SuppressionAsync_Objet_Inexistant()
        {
            //Arrange
            var MenuId=547;
            //Act
            _viewModel=new MenuViewModel();
            var result=await _viewModel.SuppressionAsync(MenuId);
            //Assert
        Assert.Null(result);
        // Assert.False(result.EstErreur);
            //Assert.Null(result.Model);
        } 
   }
}
