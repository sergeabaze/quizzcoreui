using System;
using System.Linq;
using AutoFixture;
using Quizz.UI;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.Droit.Traducteur;
using Quizz.UI.DTO;
using Quizz.Service.DTOS;
using Quizz.UI.Models;
using System.Collections.Generic;
using Xunit;

namespace Quizz.ui.Tests.Droit
{
    public class DroitTraducteurTest
    {
        Fixture _fixture;
        private readonly IDroitTraducteur _traducteur; 

        public DroitTraducteurTest(){
            _traducteur=new DroitTraducteur();
            _fixture=new Fixture();
        }

        [Fact]
        public void Test_Traducteur_Droit_FromListe_Success()
        {
            //Arrange
            var listedto=_fixture.Create<PagedResponse<DroitDto>>();
            //Act
            var result=_traducteur.FromListe(listedto);
            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.Equal(listedto.Model.ToList().Count,result.Model.ToList().Count);
        }

        [Fact]
        public void Test_Traducteur_Droit_Si_Model_Null()
        {
            //Arrange
            var listedto=_fixture.Create<PagedResponse<DroitDto>>();
            listedto.Model=null;
            listedto.DidError=true;
            //Act
            var result=_traducteur.FromListe(listedto);
            //Assert
            Assert.NotNull(result);
            Assert.True(result.EstErreur);
            Assert.Equal(result.Messages[0].Code,MessageCode.CODE_ERREUR_101);
        }

        [Fact]
        public void Test_Traducteur_Methode_FromID()
        {
            //Arrange 
            var Dto=_fixture.Create<SingleResponse<DroitDto>>();
            Dto.DidError=false;
            //Act
            var result=_traducteur.FromID(Dto);
            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.Equal(Dto.Model.Id,result.Model.Id);
        }

        [Fact]
        public void Test_FromID_Null_Message_Erreur()
        {
            //Arrange 
            var Dto=_fixture.Create<SingleResponse<DroitDto>>();
            Dto.Model=null;
            //Act
            var result=_traducteur.FromID(Dto);
            //Assert
            Assert.NotNull(result);
            Assert.True(result.EstErreur);
            Assert.Equal(result.Messages[0].Code,MessageCode.CODE_ERREUR_101);
        }


        [Fact]
        public void Test_TraduitListeVersViewModel_Retourne_Liste_Vrai()
        {
            //Arrange
            var listedto=_fixture.Create<List<DroitListDto>>();
            //Act
            var result=_traducteur.TraduitListeVersViewModel(listedto);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(listedto.Count,result.Count);
        }

        [Fact]
        public void Test_TraduitListeVersViewModel__Si_Liste_Null()
        {
            //Arrange
            List<DroitListDto> listedto=null;
            //Act
            var result=_traducteur.TraduitListeVersViewModel(listedto);
            Assert.Null(result);
        }


        [Fact]
        public void Test_TraduitVersDto_Retourne_Vrai()
        {
            //Arrange
            var viewModel=_fixture.Create<DroitRequetteViewModel>();
            //Act
            var result=_traducteur.TraduitVersDto(viewModel);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Id,viewModel.Id);
        }

        [Fact]
        public void Test_TraduitVersDto_Si_Objet_Nul()
        {
            //Arrange
            DroitRequetteViewModel viewModel=null;
            //Act
            var result=_traducteur.TraduitVersDto(viewModel);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Test_TraduitVersViewModel_Retourne_Vrai()
        {
            //Arrange
            var dto=_fixture.Create<DroitDto>();
            //Act
            var result=_traducteur.TraduitVersViewModel(dto);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(dto.Id,result.Id);
        }
        
        [Fact]
        public void Test_TraduitVersViewModel_Si_Objet_Nul()
        {
            //Arrange 
            DroitDto dto=null;
            //Act
            var result=_traducteur.TraduitVersViewModel(dto);
            //Assert
            Assert.Null(result);
        }
    }
}

 