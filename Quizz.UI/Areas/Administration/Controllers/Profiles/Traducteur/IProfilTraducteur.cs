using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Profil.Traducteur
{
  public interface IProfilTraducteur
  { 
    ProfilDto TraduitVersDto(ProfilRequetteViewModel viewModel);
    ProfilRequetteViewModel TraduitVersViewModel(ProfilDto dto);
    List<ProfilListeViewModel> TraduitListeVersViewModel(List<ProfilListDto> dtolist);

    MessagePaginationViewModel<List<ProfilAfficheViewModel>> FromListe(PagedResponse<ProfilListDto> dtos);
    MessageviewModel<ProfilRequetteViewModel> FromID(SingleResponse<ProfilDto> dto);
    MessageviewModel<ProfilRequetteViewModel> TraduitResultatPost(SingleResponse<ProfilDto> dto);

  }
}