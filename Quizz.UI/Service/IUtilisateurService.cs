using System.Threading.Tasks;
using Quizz.UI.Models;
using Quizz.UI.Models.ComptesViewModel;

namespace Quizz.UI.Services
{
  public interface IUtilisateurService
  {
   Task<MessageviewModel<UtilisateurViewModel>> EmployeLogin(LoginViewModel viewModel);

  }

}