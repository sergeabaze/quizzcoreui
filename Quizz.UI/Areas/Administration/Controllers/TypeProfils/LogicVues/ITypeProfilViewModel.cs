using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Areas.Administration.TypeProfil.LogicVues
{
  public interface ITypeProfilViewModel
  {
    Task<MessagePaginationViewModel<List<TypeProfilAfficheViewModel>>> ObtenireListAsync(int societeid, int index=1,int page =10, string libelle = null);
    Task<MessageviewModel<TypeProfilRequetteViewModel>> ObtenireParIdAsync(int id);
    Task<MessageviewModel<TypeProfilRequetteViewModel>> CreationAsync(TypeProfilRequetteViewModel model);
    Task<MessageviewModel<TypeProfilRequetteViewModel>> ModificationAsync(TypeProfilRequetteViewModel model);
    Task<MessageviewModel<TypeProfilRequetteViewModel>> SuppressionAsync(int Id);
  }
}