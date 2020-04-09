
using System.Linq;
using AutoFixture;
using Quizz.Service.DTOS;
using Quizz.UI;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.Traducteur;
using Quizz.UI.Models;
using Xunit;

namespace Quizz.ui.Tests.Employe
{
  public class EmployesTraducteurTest
  {

    Fixture _fixture;
    private readonly IEmployeTraducteur _traducteur;

    public EmployesTraducteurTest()
    {
      _traducteur = new EmployeTraducteur();
      _fixture = new Fixture();
      _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
       .ForEach(b => _fixture.Behaviors.Remove(b));
      _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public void Methode_FromListe()
    {
      //arrange
      var listeDtos = _fixture.Build<PagedResponse<EmployeListeDto>>()
      .With(xp => xp.DidError, false)
      .Create();
      //act
      var resultat = _traducteur.FromListe(listeDtos);
      //assert
      Assert.NotNull(resultat);
      Assert.NotNull(resultat.Model);
      Assert.Equal(listeDtos.Model.ToList().Count, resultat.Model.Count);
      Assert.Equal(listeDtos.PageCount, resultat.PageCount);
      Assert.Equal(listeDtos.PageNumber, resultat.PageNumber);
      Assert.Equal(listeDtos.PageSize, resultat.PageSize);

    }

    [Fact]
    public void Methode_FromListe_Vide_MessageErreur()
    {
      //arrange
      var listeDtos = _fixture.Build<PagedResponse<EmployeListeDto>>()
      .With(xp => xp.DidError, true)
      .Create();
      listeDtos.Model = null;
      //act
      var resultat = _traducteur.FromListe(listeDtos);
      //assert
      Assert.NotNull(resultat);
      Assert.Null(resultat.Model);
      Assert.True(resultat.EstErreur, "Erreur liste message , EstErreur a true attendu");
    }

    [Fact]
    public void Methode_FromID()
    {
      //arrange
      var Dto = _fixture.Build<SingleResponse<EmployeDto>>()
      .With(xp => xp.DidError, false)
      .Create();
      //act
      var resultat = _traducteur.FromID(Dto);
      //assert
      Assert.NotNull(resultat);
      Assert.NotNull(resultat.Model);
      Assert.Equal(Dto.Model.Id, resultat.Model.Id);
    }

    [Fact]
    public void Methode_FromID_NULL_Message_Erreur()
    {
      //arrange
      var Dto = _fixture.Create<SingleResponse<EmployeDto>>();
      Dto.Model = null;
      //act
      var resultat = _traducteur.FromID(Dto);
      //assert
      Assert.NotNull(resultat);
      Assert.True(resultat.EstErreur);
      Assert.Equal(resultat.Messages[0].Code, MessageCode.CODE_ERREUR_TECHNIQUE);

    }

    [Fact]
    public void Methode_TraduitResultatPost_Ok()
    {
      // arrange
      var Dto = _fixture.Create<SingleResponse<EmployeDto>>();
      Dto.DidError = false;
      //act
      var resultat = _traducteur.TraduitResultat(Dto);
      
      //assert
      Assert.NotNull(resultat);
      Assert.False(resultat.EstErreur);
      Assert.Equal(Dto.Model.Id, resultat.Model.Id);
      
    }

    [Fact]
    public void Methode_TraduitResultatErreur()
    {
      // arrange
      var Dto = _fixture.Create<SingleResponse<EmployeDto>>();
      Dto.DidError = true;
      //act
      var resultat = _traducteur.TraduitResultat(Dto);

      //assert
      Assert.NotNull(resultat);
      Assert.True(resultat.EstErreur);
      Assert.Null(resultat.Model);
      Assert.Equal(resultat.Messages[0].Code, MessageCode.CODE_ERREUR_TECHNIQUE);
    }

    [Fact]
    public void Methode_Pour_Creation_TraduitVers()
    {
      //arrange
      var viemodel = _fixture.Create<EmployeCreationViewModel>();
      viemodel.Id = 0;
      // act
      var resultatDto = _traducteur.TraduitVers(viemodel);

      //assert
      Assert.NotNull(resultatDto);
      Assert.Equal(viemodel.Id, resultatDto.Id);
      Assert.Equal(viemodel.Nom, resultatDto.Nom);
      Assert.Equal(viemodel.Email, resultatDto.Email);
    }

    [Fact]
    public void Methode_Pour_Creation_TraduitVers_Null()
    {
      //arrange
      EmployeCreationViewModel viemodel = null;
      // act
      var resultatDto = _traducteur.TraduitVers(viemodel);

      //assert
     Assert.Null(resultatDto);
     
    }
[Fact]
    public void Methode_Pour_Edition_TraduitVers()
    {
      //arrange
      var viemodel = _fixture.Create<EmployeEditionViewModel>();
      viemodel.Id = 0;
      // act
      var resultatDto = _traducteur.TraduitEditVers(viemodel);

      //assert
      Assert.NotNull(resultatDto);
      Assert.Equal(viemodel.Id, resultatDto.Id);
      Assert.Equal(viemodel.Nom, resultatDto.Nom);
      Assert.Equal(viemodel.Email, resultatDto.Email);
    }


  }
}