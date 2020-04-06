using System;
using System.Linq;
using AutoFixture;
using Moq;
using Quizz.UI.Areas.Administration.TypeClient.LogicVues;
using Quizz.UI.Areas.Administration.TypeClient.Traducteur;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Xunit;

namespace Quizz.ui.Tests.Typeclient
{
  public class TypeClientViewModeltest
  {

    Fixture _fixture;
   // private readonly ITypeClientViewModel _viewModel;
    private readonly Mock<ITypeClientTraducteur> _traducteur;

    public TypeClientViewModeltest()
    {
      _traducteur = new Mock<ITypeClientTraducteur>();
     // _viewModel = new TypeClientViewModel();
      _fixture = new Fixture();
      _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
       .ForEach(b => _fixture.Behaviors.Remove(b));
      _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

   [Fact]
    public void ObtenireListAsync_Doit_retournerListe(){

    }
      
  }
}