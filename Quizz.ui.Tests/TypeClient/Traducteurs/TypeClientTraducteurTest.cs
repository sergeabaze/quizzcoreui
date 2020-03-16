using System;
using System.Linq;
using AutoFixture;
using Quizz.UI;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.TypeClient.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Xunit;

namespace Quizz.ui.Tests.Typeclient
{
  public class TypeClientTraducteurTest
  {
    Fixture _fixture;
    private readonly ITypeClientTraducteur _traducteur;

    public TypeClientTraducteurTest(){
      _traducteur = new TypeClientTraducteur();
      _fixture = new Fixture();
      _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
       .ForEach(b => _fixture.Behaviors.Remove(b));
      _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

     [Fact]
    public void Methode_FromListe(){
      //arrange
       var listeDtos =_fixture.Build<PagedResponse<TypeClientDto>>()
       .With(xp=>xp.DidError,false)
       .Create();
      //act
        var resultat = _traducteur.FromListe(listeDtos);
      //assert
        Assert.NotNull(resultat);
        Assert.NotNull(resultat.Model);
        Assert.Equal(listeDtos.Model.ToList().Count ,resultat.Model.Count);

    }

    [Fact]
    public void Methode_FromListe_MessageErreur()
    {
      //arrange
      var listeDtos = _fixture.Create<PagedResponse<TypeClientDto>>();
      listeDtos.Model = null ;
      listeDtos.DidError =true;
      //act
      var resultat = _traducteur.FromListe(listeDtos);
      //assert
      Assert.NotNull(resultat);
      Assert.True(resultat.EstErreur );
      Assert.Equal(resultat.Messages[0].Code, MessageCode.CODE_ERREUR_101);
    }

    [Fact]
    public void Methode_FromID()
    {
      //arrange
      var Dto = _fixture.Build<SingleResponse<TypeClientDto>>()
      .With(xp=>xp.DidError, false)
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
      var Dto = _fixture.Create<SingleResponse<TypeClientDto>>();
       Dto.Model= null;
      //act
     var resultat = _traducteur.FromID(Dto);
      //assert
     Assert.NotNull(resultat);
     Assert.True(resultat.EstErreur);
     Assert.Equal(resultat.Messages[0].Code,MessageCode.CODE_ERREUR_101);

    }

    [Fact]
    public void Methode_Pour_Creation_TraduitVers(){
      //arrange
       var viemodel =_fixture.Create<TypeClientRequetteViewModel>();
         viemodel.Id = 0;
      // act
       var resultatDto = _traducteur.TraduitVers(viemodel);
     
     //assert
      Assert.NotNull(resultatDto);
      Assert.Equal(viemodel.Id, resultatDto.Id);
      Assert.Equal(viemodel.Code, resultatDto.Code);
      Assert.Equal(viemodel.Libelle, resultatDto.Libelle);
    }

    [Fact]
    public void Methode_Pour_MiseJour_TraduitVers()
    {
      //arrange
      var viemodel = _fixture.Create<TypeClientRequetteViewModel>();
      // act
      var resultatDto = _traducteur.TraduitVers(viemodel);
      //assert
      Assert.NotNull(resultatDto);
      Assert.Equal(viemodel.Id, resultatDto.Id);
      Assert.Equal(viemodel.Code, resultatDto.Code);
      Assert.Equal(viemodel.Libelle, resultatDto.Libelle);

    }

    [Fact]
    public void Methode_TraduitResultatPost_Ok()
    {
      // arrange
       var Dto = _fixture.Create<SingleResponse<TypeClientDto>>();
        Dto.DidError = false;
      //act
        var resultat = _traducteur.TraduitResultatPost(Dto);
      // MessageviewModel<TypeClientRequetteViewModel> TraduitResultatPost(SingleResponse<TypeClientDto> dto);
      //assert
      Assert.NotNull(resultat);
      Assert.False(resultat.EstErreur);
      Assert.Equal(Dto.Model.Id,resultat.Model.Id);
    }

    [Fact]
    public void Methode_TraduitResultatPost_Error()
    {
      // arrange
      var Dto = _fixture.Create<SingleResponse<TypeClientDto>>();
       Dto.Model =null;
      //act
      var resultat = _traducteur.TraduitResultatPost(Dto);
      // MessageviewModel<TypeClientRequetteViewModel> TraduitResultatPost(SingleResponse<TypeClientDto> dto);
      //assert
      Assert.NotNull(resultat);
      Assert.True(resultat.EstErreur);
      Assert.Equal(resultat.Messages[0].Code, MessageCode.CODE_ERREUR_101);
    }

  }
}