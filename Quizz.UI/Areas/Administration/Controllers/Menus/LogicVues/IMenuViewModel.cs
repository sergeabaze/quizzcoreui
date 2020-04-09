using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Areas.Administration.Menu.LogicVues
{
  public interface IMenuViewModel
  {
   Task<MessagePaginationViewModel<List<MenuAfficheViewModel>>> ObtenireListAsync(int societeid, int index=1,int page =10, string libelle = null);
    Task<MessageviewModel<MenuRequetteViewModel>> ObtenireParIdAsync(int id);
    Task<MessageviewModel<MenuRequetteViewModel>> CreationAsync(MenuRequetteViewModel model);
    Task<MessageviewModel<MenuRequetteViewModel>> ModificationAsync(MenuRequetteViewModel model);
    Task<MessageviewModel<MenuRequetteViewModel>> SuppressionAsync(int Id);
  }
}