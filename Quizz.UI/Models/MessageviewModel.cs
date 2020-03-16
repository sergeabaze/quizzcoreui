using System.Collections.Generic;

namespace Quizz.UI.Models
{
  public class MessageviewModel<T>
  {
   public T Model {get; set;}
    public string Message { get; set; }
   public bool EstErreur {get;set;}
   public List<MessageErreurs> Messages{get;set;}
  }

  public class MessagePaginationViewModel<T>
  {
    public T Model { get; set; }
    public bool EstErreur { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int ItemCount { get; set; }
    public double PageCount { get; set; }
    public List<MessageErreurs> Messages { get; set; }
  }

}