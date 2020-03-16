using System.Threading.Tasks;

namespace Quizz.Service
{
  public interface IServiceGenerique<T>
  {
    Task<T> ObtenirelisteAsync();
  }
    
}