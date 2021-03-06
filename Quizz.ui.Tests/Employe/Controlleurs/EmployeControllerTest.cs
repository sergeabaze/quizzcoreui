using Xunit;
using System.Linq;
using AutoFixture;
using Moq;
using Quizz.UI.Areas.Administration.LogicVues;
using Quizz.UI.Areas.Administration.controllers.Employe;
using Microsoft.Extensions.Logging;
using Quizz.UI.Areas.Administration.Traducteur;

namespace Quizz.ui.Tests.Employe
{
  public class EmployeControllerTest
  {

    Fixture _fixture;
    private readonly Mock<IEmployeViewModel> _viewModel;
    private readonly Mock<ILogger<EmployeController>> _logger;
    private readonly Mock<IEmployeTraducteur> _traducteur;
    private readonly EmployeController controlleur;
    public EmployeControllerTest()
    {
      _viewModel = new Mock<IEmployeViewModel>();
      _logger = new Mock<ILogger<EmployeController>>();
      _traducteur = new Mock<IEmployeTraducteur>();

      _fixture = new Fixture();
      _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
       .ForEach(b => _fixture.Behaviors.Remove(b));
      _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
      controlleur = new EmployeController(_logger.Object, _viewModel.Object, _traducteur.Object);

    }
  }
}