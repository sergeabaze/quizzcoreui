using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.UI.Services;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.LogicVues
{
  public interface ISocieteViewModel
  {
    Task<MessagePaginationViewModel<List<SocieteAfficheViewModel>>> ObtenireListAsync(int societeid, int index=1,int page =10, string libelle = null);
    Task<MessageviewModel<SocieteRequetteViewModel>> ObtenireParIdAsync(int id);
    Task<MessageviewModel<SocieteRequetteViewModel>> CreationAsync(SocieteRequetteViewModel model);
    Task<MessageviewModel<SocieteRequetteViewModel>> ModificationAsync(SocieteRequetteViewModel model);
    Task<MessageviewModel<SocieteRequetteViewModel>> SuppressionAsync(int Id);
  }

}