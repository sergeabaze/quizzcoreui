using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Areas.Administration.ProfilEmployer.LogicVues
{
  public interface IProfilEmployerViewModel
  {
    Task<MessagePaginationViewModel<List<ProfilEmployerAfficheViewModel>>> ObtenireListAsync(int societeid, int index = 1, int page = 10, string libelle = null);
    Task<MessageviewModel<ProfilEmployerRequetteViewModel>> ObtenireParIdAsync(int id);
    Task<MessageviewModel<ProfilEmployerRequetteViewModel>> CreationAsync(ProfilEmployerRequetteViewModel model);
    Task<MessageviewModel<ProfilEmployerRequetteViewModel>> ModificationAsync(ProfilEmployerRequetteViewModel model);
    Task<MessageviewModel<ProfilEmployerRequetteViewModel>> SuppressionAsync(int Id);
  }
}