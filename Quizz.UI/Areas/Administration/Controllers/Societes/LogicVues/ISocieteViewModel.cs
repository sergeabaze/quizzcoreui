using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Areas.Administration.Societe.LogicVues
{
  public interface ISocieteViewModel
  {
    Task<IEnumerable<SocieteListeViewModel>> ObtenireListAsync() ;
    Task<SocieteRequetteViewModel> ObtenireParIdAsync(int ID);
      
    
  }

}