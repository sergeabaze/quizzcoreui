using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.UI.Services;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Profil.LogicVues
{
  public interface IProfilViewModel
  {
    Task<MessagePaginationViewModel<List<ProfilAfficheViewModel>>> ObtenireListAsync(int Profilid, int index=1,int page =10, string libelle = null);
    Task<MessageviewModel<ProfilRequetteViewModel>> ObtenireParIdAsync(int id);
    Task<MessageviewModel<ProfilRequetteViewModel>> CreationAsync(ProfilRequetteViewModel model);
    Task<MessageviewModel<ProfilRequetteViewModel>> ModificationAsync(ProfilRequetteViewModel model);
    Task<MessageviewModel<ProfilRequetteViewModel>> SuppressionAsync(int Id);
    Task<MessageviewModel<ProfilRequetteViewModel>> SuppressionAsync(ProfilRequetteViewModel model);
  }

}