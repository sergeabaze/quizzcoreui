using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Menu.Traducteur
{
  public interface IMenuTraducteur
  { 
    MenuDto TraduitVersDto(MenuRequetteViewModel viewModel);
    MenuRequetteViewModel TraduitVersViewModel(MenuDto dto);
    List<MenuListeViewModel> TraduitListeVersViewModel(List<MenuListDto> dtolist);

    MessagePaginationViewModel<List<MenuAfficheViewModel>> FromListe(PagedResponse<MenuDto> dtos);
    MessageviewModel<MenuRequetteViewModel> FromID(SingleResponse<MenuDto> dto);
    MessageviewModel<MenuRequetteViewModel> TraduitResultatPost(SingleResponse<MenuDto> dto);

  }
}