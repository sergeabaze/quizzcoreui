using Microsoft.AspNetCore.Http;

namespace Quizz.UI
{
  public class SessionIndexer
  {
    private ISession Session;
    public SessionIndexer(ISession Session)
    {
      this.Session = Session;
    }
   /* public object this[string key]
    {
      set
      {
        Session.SetObject(key, value);
      }
      get
      {
        return Session.GetObject(key);
      }
    }*/
   
  }
}