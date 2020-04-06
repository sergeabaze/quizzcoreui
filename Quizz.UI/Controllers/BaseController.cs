using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Quizz.UI.Models;
using Quizz.UI.Models.ComptesViewModel;
using static System.Net.WebRequestMethods;

namespace Quizz.UI.Controllers
{

  public abstract class BaseController : Controller
  {
   //public Http.SmartCookies Cookies { get { return HttpContext.RequestServices?.GetService<Http.SmartCookies>(); } }
   // public IConfiguration Configuration { get { return HttpContext.RequestServices?.GetService<IConfiguration>(); } }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      Prepare();
      base.OnActionExecuting(context);
    }

    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      Prepare();
      return base.OnActionExecutionAsync(context, next);
    }

    public virtual void Prepare()
    {
       
    }

    public UtilisateurViewModel SessionUtilisateur {
      get {
        var session = HttpContext.Session.Get<UtilisateurViewModel>("userconnect");
        return session;
      }
    }
   
  }

}