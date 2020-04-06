using System.Net.Http;
using System.Threading.Tasks;

namespace Quizz.UI.Communs
{

  public interface IHttpCustomClientFactory
  {
    Task<HttpResponseMessage> Get(string requestUri);
    Task<HttpResponseMessage> Post(string requestUri, object value);
    Task<HttpResponseMessage> Put(string requestUri, object value);
    Task<HttpResponseMessage> Patch(string requestUri, object value);
    Task<HttpResponseMessage> Delete(string requestUri);
  }

}