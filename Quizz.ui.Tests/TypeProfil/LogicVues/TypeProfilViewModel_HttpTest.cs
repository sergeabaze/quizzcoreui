using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Quizz.UI;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.TypeProfil.LogicVues;
using Quizz.UI.Areas.Administration.TypeProfil.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Xunit;
namespace Quizz.ui.Tests.TypeProfil
{
  public class TypeProfilViewModel_HttpTest
  {
      Fixture _fixture;
      private ITypeProfilViewModel _viewModel;

      public TypeProfilViewModel_HttpTest()
      {
          _fixture=new Fixture();
      }

     [Fact]
     public async Task RechercheAsync_TypeProfil_Doit_Retourner_Vrai()
     {
         //Arrange
         _viewModel=new TypeProfilViewModel();
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
          _viewModel=new TypeProfilViewModel();
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
          _viewModel=new TypeProfilViewModel();
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
          var typeprofil= new TypeProfilRequetteViewModel{Id=0,Code="MCV",Libelle="Marketing"};
          //Act
         _viewModel=new TypeProfilViewModel();
          var result= await _viewModel.CreationAsync(typeprofil);
          //Assert
          Assert.NotNull(result);
          Assert.NotNull(result.Model);
          Assert.False(result.EstErreur);
      } 

      [Fact]
      public async Task CreationAsync_Avec_Echec_Doublons()
      {
           //Arrange
         var typeprofil=new TypeProfilRequetteViewModel{Id=0,Code="MCV",Libelle="Marketing"};
          //Act
         _viewModel=new TypeProfilViewModel();
          var result= await _viewModel.CreationAsync(typeprofil);
          //Assert 
          Assert.Equal(result.Messages[0].Libelle,"Creation impossible Cet Objet exite deja dans la base");
          Assert.False(result.EstErreur);
      }
    
      [Fact]
      public async Task MiseAJour_TypeProfil_Retourne_200()
      {
             //Arrange
         var typeprofil=new TypeProfilRequetteViewModel{Id=5,Code="Sakoi",Libelle="Sde"};
          //Act
         _viewModel=new TypeProfilViewModel();
          var result= await _viewModel.ModificationAsync(typeprofil);
          //Assert 
          Assert.NotNull(result);
          // Assert.Equal(result.Messages[0].Libelle,"Creation impossible Cet Objet exite deja dans la base");
         // Assert.True(result.EstErreur);
      }

        [Fact]
        public async Task MiseAJour_TypeProfil_Retourne_400()
        {
                //Arrange
            var typeprofil=new TypeProfilRequetteViewModel{Id=506,Code="Skeco",Libelle="se"};
            //Act
            _viewModel=new TypeProfilViewModel();
            var result= await _viewModel.ModificationAsync(typeprofil);
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
            var typeProfilId=6;
            //Act
            _viewModel=new TypeProfilViewModel();
            var result=await _viewModel.SuppressionAsync(typeProfilId);
            //Assert
            Assert.Equal("Suppression de lobjet",result.Messages[0].Libelle);
        }  
        [Fact]
        public async Task SuppressionAsync_Objet_Inexistant()
        {
            //Arrange
            var typeProfilId=547;
            //Act
            _viewModel=new TypeProfilViewModel();
            var result=await _viewModel.SuppressionAsync(typeProfilId);
            //Assert
        Assert.Null(result);
        // Assert.False(result.EstErreur);
            //Assert.Null(result.Model);
        } 
   }
}
