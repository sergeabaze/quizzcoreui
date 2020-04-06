using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;

namespace Quizz.UI.Areas.Administration.LogicVues
{
  public interface IEmployeViewModel
  {
    Task<MessagePaginationViewModel<List<EmployeAfficheViewModel>>> ObtenireListAsync(int societeid, int index = 1, int pageCount = 10,
     string nom = null, string matricule = null, string telephone = null,string email = null);
   Task<MessageviewModel<EmployerequetteViewModel>> ObtenireParIdAsync(int id);
  
  Task<MessageviewModel<EmployerequetteViewModel>> CreationAsync(EmployeCreationViewModel model);
  Task<MessageviewModel<EmployerequetteViewModel>> ModificationAsync(EmployeEditionViewModel model);
    Task<MessageviewModel<EmployerequetteViewModel>> SuppressionAsync(int Id);
    // Task<MessageviewModel<EmployerequetteViewModel>> SuppressionAsync(TypeClientRequetteViewModel model);

  }
    
}