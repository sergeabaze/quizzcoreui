using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Droit.Traducteur
{
  public interface IDroitTraducteur
  { 
    DroitDto TraduitVersDto(DroitRequetteViewModel viewModel);
    DroitRequetteViewModel TraduitVersViewModel(DroitDto dto);
    List<DroitListeViewModel> TraduitListeVersViewModel(List<DroitListDto> dtolist);

     MessagePaginationViewModel<List<DroitAfficheViewModel>> FromListe(PagedResponse<DroitDto> dtos);
    MessageviewModel<DroitRequetteViewModel> FromID(SingleResponse<DroitDto> dto);
    MessageviewModel<DroitRequetteViewModel> TraduitResultatPost(SingleResponse<DroitDto> dto);
  }
}