using System.Collections.Generic;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Models;
using Quizz.Service.DTOS;

namespace Quizz.UI.Areas.Administration.Traducteur
{

  public interface IEmployeTraducteur
  {
     MessagePaginationViewModel<List<EmployeAfficheViewModel>> FromListe(PagedResponse<EmployeListeDto> dtos);
     MessageviewModel<EmployerequetteViewModel> FromID(SingleResponse<EmployeDto> dto);
     EmployeCreationDto TraduitVers(EmployeCreationViewModel viewModel);
     EmployeEditionDto TraduitEditVers(EmployeEditionViewModel viewModel);
     MessageviewModel<EmployeReponseViewModel> TraduitResultat(SingleResponse<EmployeDto> dto);

    EmployeEditionViewModel TraduitVersViewModel(EmployerequetteViewModel dto);
      
  }

}