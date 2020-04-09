using Xunit;
using System.Linq;
using AutoFixture;
using Moq;
using Quizz.UI.Services;
using Quizz.UI.Models.ComptesViewModel;
using System.Threading.Tasks;

namespace Quizz.ui.Tests.Employe
{
  public class UtilisateurServiceTest
  {
    Fixture _fixture;
 //  private readonly Mock<IEmployeTraducteur> _traducteur;
    private readonly IUtilisateurService _service;
    public UtilisateurServiceTest()
    {

      _service = new UtilisateurService();
      _fixture = new Fixture();
      _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
       .ForEach(b => _fixture.Behaviors.Remove(b));
      _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

    }

    [Fact]
    public async Task LoginAsync_Doit_retournerEmployer_Liste_profile_Droits()
    {

      //arrange
      var requette = _fixture.Create<LoginViewModel>();

      //act
      var reponse =await _service.EmployeLogin(requette);

      //assert
      Assert.NotNull(reponse);

    }
  }
}