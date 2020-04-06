using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;

namespace Quizz.UI.Areas.Administration.LogicVues
{
  public class SocieteViewModel :ISocieteViewModel
  {

    public SocieteViewModel(){
      
    }

    public Task<IEnumerable<SocieteListeViewModel>> ObtenireListAsync()
    {
      var result =new  List<SocieteListeViewModel> { 
        new SocieteListeViewModel {Id = 1, Designation ="Societe teste1" , RaisonSociale = "SA" , Telephone ="23760609874"},
        new SocieteListeViewModel {Id = 10, Designation ="Societe teste10" , RaisonSociale = "SA" , Telephone ="23760609874"}
      }.AsEnumerable();
      return Task.FromResult(result);
    }

    public Task<SocieteRequetteViewModel> ObtenireParIdAsync(int ID)
    {
       var model = new SocieteRequetteViewModel {Id = 1, Designation = "Societe teste1", RaisonSociale = "SA", Telephone = "23760609874" };
        return Task.FromResult(model);
    }
  }

}