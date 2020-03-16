using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

public class AuthorizedAction : ActionFilterAttribute
{
  public override void OnResultExecuting(ResultExecutingContext filterContext)
  {

  }
  public override void OnActionExecuting(ActionExecutingContext filterContext)
  {
    base.OnActionExecuting(filterContext);
    
    Controller controller = filterContext.Controller as Controller;

    if (filterContext.HttpContext.Session.GetString("email") == null)
    {
      filterContext.Result = new RedirectToRouteResult(
          new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
      return;
    }
  }
}
