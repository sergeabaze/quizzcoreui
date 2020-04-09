using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.TypeProfil.Traducteur
{
  public interface ITypeProfilTraducteur
  { 
    TypeProfilDto TraduitVersDto(TypeProfilRequetteViewModel viewModel);
    TypeProfilRequetteViewModel TraduitVersViewModel(TypeProfilDto dto);
    List<TypeProfilListeViewModel> TraduitListeVersViewModel(List<TypeProfilListDto> dtolist);

    MessagePaginationViewModel<List<TypeProfilAfficheViewModel>> FromListe(PagedResponse<TypeProfilDto> dtos);
    MessageviewModel<TypeProfilRequetteViewModel> FromID(SingleResponse<TypeProfilDto> dto);
    MessageviewModel<TypeProfilRequetteViewModel> TraduitResultatPost(SingleResponse<TypeProfilDto> dto);
  }
}