using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Areas.Administration.TypeClient.LogicVues
{
  public interface ITypeClientViewModel
  {
    Task<MessagePaginationViewModel<List<TypeClientAfficheViewModel>>> ObtenireListAsync(int societeid, int index=1,int page =10, string libelle = null);
    Task<MessageviewModel<TypeClientRequetteViewModel>> ObtenireParIdAsync(int id);
    Task<MessageviewModel<TypeClientRequetteViewModel>> CreationAsync(TypeClientRequetteViewModel model);
    Task<MessageviewModel<TypeClientRequetteViewModel>> ModificationAsync(TypeClientRequetteViewModel model);
    Task<MessageviewModel<TypeClientRequetteViewModel>> SuppressionAsync(int Id);
    Task<MessageviewModel<TypeClientRequetteViewModel>> SuppressionAsync(TypeClientRequetteViewModel model);
  }
}