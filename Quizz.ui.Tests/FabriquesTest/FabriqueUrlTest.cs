using System.Collections.Generic;
using AutoFixture;
using Quizz.UI.Communs;
using Xunit;

namespace  Quizz.ui.Tests.Fabriques
{
  public class FabriqueUrlTest
  {
   // Fixture _fixture;
    private IDictionary<string, object> _parameters;
   // private readonly ITypeClientTraducteur _traducteur;

    public FabriqueUrlTest(){
      _parameters = new Dictionary<string, object>();

    }

    [Fact]
    public void Methode_Get()
    {
      //arrange
      var url ="http://www.monsite.com";

      //act
       var resultUrl = FabriqueUrl.GetUrl(EnumerateActionHttp.GET, url, _parameters);

      //assert
     // Assert.Equal(resultUrl,"teste");

    }

      
  }
    
}