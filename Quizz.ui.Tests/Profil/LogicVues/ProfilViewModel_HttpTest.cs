using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Quizz.UI;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.Profil.LogicVues;
using Quizz.UI.Areas.Administration.Profil.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Xunit;
namespace Quizz.ui.Tests.Profil
{
  public class ProfilViewModel_HttpTest
  {
      Fixture _fixture;
      private IProfilViewModel _viewModel;

      public ProfilViewModel_HttpTest()
      {
          _fixture=new Fixture();
      }

     [Fact]
     public async Task RechercheAsync_Profil_Doit_Retourner_Vrai()
     {
         //Arrange
         _viewModel=new ProfilViewModel();
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
          _viewModel=new ProfilViewModel();
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
          _viewModel=new ProfilViewModel();
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
          var Profil= new ProfilRequetteViewModel{
                                        Id=0,
                                        TypeProfilId=2,
                                        Code="ddddd",
                                        Libelle="jjkdhkjdjshfkdjs"
                                        };
          //Act
         _viewModel=new ProfilViewModel();
          var result= await _viewModel.CreationAsync(Profil);
          //Assert
          Assert.NotNull(result);
          Assert.NotNull(result.Model);
          Assert.False(result.EstErreur);
      } 

      [Fact]
      public async Task CreationAsync_Avec_Echec_Doublons()
      {
           //Arrange
         var Profil=new ProfilRequetteViewModel{
                                    Id=0,
                                    TypeProfilId=2,
                                    Code="ddddd",
                                    Libelle="jjkdhkjdjshfkdjs"
                                    };
        //Act
         _viewModel=new ProfilViewModel();
          var result= await _viewModel.CreationAsync(Profil);
          //Assert 
          Assert.Equal(result.Messages[0].Libelle,"Creation impossible Cet Objet exite deja dans la base");
          Assert.False(result.EstErreur);
      }
    
      [Fact]
      public async Task MiseAJour_Profil_Retourne_200()
      {
             //Arrange
         var Profil=new ProfilRequetteViewModel{
                                    Id=2,
                                    TypeProfilId=2,
                                    Code="ddddd",
                                    Libelle="jjkdhkjdjshfkdjs"
                                    };
          //Act
         _viewModel=new ProfilViewModel();
          var result= await _viewModel.ModificationAsync(Profil);
          //Assert 
          Assert.NotNull(result);
          // Assert.Equal(result.Messages[0].Libelle,"Creation impossible Cet Objet exite deja dans la base");
         // Assert.True(result.EstErreur);
      }

        [Fact]
        public async Task MiseAJour_Profil_Retourne_400()
        {
                //Arrange
            var Profil=new ProfilRequetteViewModel{
                                Id=0,
                                TypeProfilId=2,
                                Code="ddddd",
                                Libelle="jjkdhkjdjshfkdjs"
                                };
            //Act
            _viewModel=new ProfilViewModel();
            var result= await _viewModel.ModificationAsync(Profil);
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
            var ProfilId=6;
            //Act
            _viewModel=new ProfilViewModel();
            var result=await _viewModel.SuppressionAsync(ProfilId);
            //Assert
            Assert.Equal("Suppression de lobjet",result.Messages[0].Libelle);
        }  
        [Fact]
        public async Task SuppressionAsync_Objet_Inexistant()
        {
            //Arrange
            var ProfilId=547;
            //Act
            _viewModel=new ProfilViewModel();
            var result=await _viewModel.SuppressionAsync(ProfilId);
            //Assert
        Assert.Null(result);
        // Assert.False(result.EstErreur);
            //Assert.Null(result.Model);
        } 
   }
}
