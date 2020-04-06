using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.LogicVues;
using Quizz.UI.Areas.Administration.Traducteur;
using Quizz.UI.Controllers;

namespace Quizz.UI.Areas.Administration.controllers.TypeClient
{
  [Area("Administration")]
  [AuthorizedAction]
  public class TypeClientController : BaseController
  {
    #region Proprietes
    private readonly ILogger<TypeClientController> _logger;
    private readonly ISocieteViewModel _service;
    private readonly ISocieteTraducteur _traducteur;
    //private readonly MySettings _mySettings;
    #endregion

    #region Constructeurs
    public TypeClientController(ILogger<TypeClientController> logger,
                                     ISocieteViewModel service,
                                 ISocieteTraducteur traducteur)
    {
      _logger = logger;
      _service = service;
      _traducteur = traducteur;
      _logger.LogInformation("TypeClientController- constructeur");
    }

    #endregion

  }

}