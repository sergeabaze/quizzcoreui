using System.Collections.Generic;
using Quizz.DomainModel.Enums;
using System.Linq;
using Quizz.DomainModel.Enums.Display;

namespace Quizz.UI.Communs.htmlHelper
{
  public static class ComboBoxValuesHelper
  {
  /*  public static ListEditItemCollection TypeEmployesValues
    {
      get { return GetCollection<TypeEmployeEnum>(); }
    }

    public static ListEditItemCollection GetCollection<T>() where T : struct
    {
      return GetCollection<T>(null);
    }

*/
   /* public static ListEditItemCollection GetCollection<T>(string caption)
      where T : struct
    {
      var collection = new ListEditItemCollection();
      var values = GetKeysAndValues<T>();
      if (!string.IsNullOrEmpty(caption))
        collection.Add(caption, 0);
      collection.AddRange(values.Select(pair => new ListEditItem(pair.Value.ToString(), pair.Key)).ToList());
      return collection;
    }*/

    public static List<KeyValuePair<int, string>> GetKeysAndValues<T>()
      where T : struct
    {
      var values = System.Enum.GetValues(typeof(T));
      var list = new List<KeyValuePair<int, string>>();
      foreach (var value in values)
      {
        list.Add(new KeyValuePair<int, string>((int)value, EnumHelper.GetDescription((System.Enum)value)));
      }
      return list;
    }
      
  } 
    
}