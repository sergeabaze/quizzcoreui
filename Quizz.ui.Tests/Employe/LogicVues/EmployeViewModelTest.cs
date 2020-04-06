using Xunit;
using System.Linq;
using AutoFixture;
using Moq;
using Quizz.UI.Areas.Administration.Traducteur;
using Quizz.UI.Areas.Administration.LogicVues;
using System.Threading.Tasks;
using Quizz.UI.Models;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Communs;
using Quizz.Service;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Moq.Protected;
using System.Threading;
using System;
using FluentAssertions;
using Quizz.Service.DTOS;

namespace Quizz.ui.Tests.Employe
{
  public class EmployeViewModelTest
  {

    Fixture _fixture;
    private readonly Mock<IEmployeTraducteur> _traducteur;
    private readonly Mock<HttpCustomClientFactory> _factoryhttpclient;
    private readonly Mock<HttpClient> _httpclient;
    private readonly IEmployeViewModel _viewModel;
    public EmployeViewModelTest(){
      _traducteur = new Mock<IEmployeTraducteur>();
      _factoryhttpclient = new Mock<HttpCustomClientFactory>();
      _httpclient = new Mock<HttpClient>();
       _viewModel = new EmployeViewModel();
      _fixture = new Fixture();
      _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
       .ForEach(b => _fixture.Behaviors.Remove(b));
      _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

    }

    [Fact]
    public async Task ObtenireParIdAsync_doit_retenire_Employe()
    {
      //arrange
     var requette = _fixture.Create<int>();
     var attendu = _fixture.Create<MessageviewModel<EmployerequetteViewModel>>();
      _traducteur.Setup(x=>x.FromID(It.IsAny<SingleResponse<EmployeDto>>())).Returns(_fixture.Create<MessageviewModel<EmployerequetteViewModel>>());
     var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
      handlerMock
      .Protected()
   // Setup the PROTECTED method to mock
   .Setup<Task<HttpResponseMessage>>(
      "SendAsync",
      ItExpr.IsAny<HttpRequestMessage>(),
      ItExpr.IsAny<CancellationToken>()
   )
   // prepare the expected response of the mocked http call
   .ReturnsAsync(new HttpResponseMessage()
   {
     StatusCode = HttpStatusCode.OK,
     Content = new StringContent(attendu.ToString()),
   })
   .Verifiable();

      // use real http client with mocked handler here
      var httpClient = new HttpClient(handlerMock.Object)
      {
        BaseAddress = new Uri("http://localhost:60/api/v1/Employe/1"),
      };

      var reponse = await _viewModel.ObtenireParIdAsync(requette);

      //assert fluent
      Assert.NotNull(reponse);
      reponse.Should()
      .NotBeNull();
     // reponse.Model.Should().Be(1);
    }
  }
}