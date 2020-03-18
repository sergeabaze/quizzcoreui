
using System.Collections.Generic;
using System.Linq;

namespace Quizz.UI.Communs
{

  public static class FabriqueUrl
  {
    public static string GetUrl(EnumerateActionHttp _action, string _url, IDictionary<string, object> _parameters )
    {
      int action = (int)_action;
      string url = null;

      switch (action)
      {
          case 1:{
           // url = _url.AddQueryString(_parameters.Select(u => $"{u.Key}={u.Value}"));
            break;
          }
          default:{
            break;
          }
      }
      return url;
    }
    public static string AddQueryString(this string url, IDictionary<string, object> parameters) =>
     $"{url}?{parameters.ToQueryString()}";

    private static string ToQueryString(this IDictionary<string, object> parameters) =>
   string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
    //string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
      
  }
    
}