using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quizz.UI.Models;
using Quizz.UI.Services;

namespace Quizz.UI.Controllers
{
     
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly IOptions<MySettingsModel> appsetting;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           ApplicationSettings.WebApiUrl = "";
        }

        public IActionResult Index()
        {
          _logger.LogInformation("Affiche HomeController-->index");
            var session= HttpContext.Session.Get<SessionUserModel>("userconnect");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
