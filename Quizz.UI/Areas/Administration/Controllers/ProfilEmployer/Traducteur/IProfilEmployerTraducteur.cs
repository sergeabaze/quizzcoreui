using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.ProfilEmployer.Traducteur
{
  public interface IProfilEmployerTraducteur
  {
    ProfilEmployerDto TraduitVersDto(ProfilEmployerRequetteViewModel viewModel);
    ProfilEmployerRequetteViewModel TraduitVersViewModel(ProfilEmployerDto dto);
    List<ProfilEmployerListeViewModel> TraduitListeVersViewModel(List<ProfilEmployerListDto> dtolist);

    MessagePaginationViewModel<List<ProfilEmployerAfficheViewModel>> FromListe(PagedResponse<ProfilEmployerDto> dtos);
    MessageviewModel<ProfilEmployerRequetteViewModel> FromID(SingleResponse<ProfilEmployerDto> dto);
    MessageviewModel<ProfilEmployerRequetteViewModel> TraduitResultatPost(SingleResponse<ProfilEmployerDto> dto);
  }
}