using System.Collections.Generic;
using Quizz.DomainModel.Enums;
using System.Linq;
using Quizz.DomainModel.Enums.Display;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quizz.UI.Communs.htmlHelper
{
  public static class ComboBoxValuesHelper
  {
   public static List<SelectListItem> TypeEmployesValues
    {
      get { return GetCollection<TypeEmployeEnum>("Select Type Employes"); }
    }
    /* 
        public static ListEditItemCollection GetCollection<T>() where T : struct
        {
          return GetCollection<T>(null);
        }

    */
    public static List<SelectListItem> GetCollection<T>(string caption)
      where T : struct
    {
      var collection = new List<SelectListItem>();
      var values = GetKeysAndValues<T>();
      if (!string.IsNullOrEmpty(caption))
        collection.Add(new SelectListItem() { Text = caption, Value = "0" });
      //new SelectList(lista, "Id", "Nome");
       collection.AddRange(values.Select(pair => new SelectListItem() {Text = pair.Value.ToString(), Value =pair.Key.ToString()}).ToList());
      return collection;
    }

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