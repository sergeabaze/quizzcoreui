using System.Collections.Generic;

namespace Quizz.UI.Services
{
  public interface IVueModelGeneric<Tmodel>
  {
     List<Tmodel> ObtenireListe();
     Tmodel obtenireParId(int ID);
      
  }
    
}