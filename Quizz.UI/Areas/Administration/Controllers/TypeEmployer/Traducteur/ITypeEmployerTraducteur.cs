using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.TypeEmployer.Traducteur
{
  public interface ITypeEmployerTraducteur
  { 
    TypeEmployerDto TraduitVersDto(TypeEmployerRequetteViewModel viewModel);
    TypeEmployerRequetteViewModel TraduitVersViewModel(TypeEmployerDto dto);
    List<TypeEmployerListeViewModel> TraduitListeVersViewModel(List<TypeEmployerListDto> dtolist);

    MessagePaginationViewModel<List<TypeEmployerAfficheViewModel>> FromListe(PagedResponse<TypeEmployerDto> dtos);
    MessageviewModel<TypeEmployerRequetteViewModel> FromID(SingleResponse<TypeEmployerDto> dto);
    MessageviewModel<TypeEmployerRequetteViewModel> TraduitResultatPost(SingleResponse<TypeEmployerDto> dto);
  }
}