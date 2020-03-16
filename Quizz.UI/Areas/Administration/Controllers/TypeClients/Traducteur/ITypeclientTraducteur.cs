using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.DTO;
using Quizz.UI.Models;

namespace Quizz.UI.Areas.Administration.TypeClient.Traducteur
{

  public interface ITypeClientTraducteur
  {
    MessagePaginationViewModel<List<TypeClientAfficheViewModel>> FromListe(PagedResponse<TypeClientDto> dtos);
    MessageviewModel<TypeClientRequetteViewModel> FromID(SingleResponse<TypeClientDto> dto);
    TypeClientRequetteDto TraduitVers(TypeClientRequetteViewModel viewModel);
    MessageviewModel<TypeClientRequetteViewModel> TraduitResultatPost(SingleResponse<TypeClientDto> dto);

      
  }
    
}