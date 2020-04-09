using System.Collections.Generic;
using Quizz.Service.DTOS;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;

namespace Quizz.UI.Areas.Administration.Traducteur
{
  public interface ISocieteTraducteur
  {
      SocieteDto TraduitVersDto(SocieteRequetteViewModel viewModel);
      SocieteRequetteViewModel TraduitVersViewModel(SocieteDto dto);
      List<SocieteListeViewModel> TraduitListeVersViewModel(List<SocieteListDto> dtolist);

      MessagePaginationViewModel<List<SocieteAfficheViewModel>> FromListe(PagedResponse<SocieteDto> dtos);
      MessageviewModel<SocieteRequetteViewModel> FromID(SingleResponse<SocieteDto> dto);
      MessageviewModel<SocieteRequetteViewModel> TraduitResultatPost(SingleResponse<SocieteDto> dto);
  } 
}