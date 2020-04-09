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

namespace Quizz.UI.Areas.Administration.controllers.Societe
{
 
  [Area("Administration")]
  [AuthorizedAction]
  public class SocieteController: BaseController
  {
    #region Proprietes
    private readonly ILogger<SocieteController> _logger;
    private readonly ISocieteViewModel _service;
    private readonly ISocieteTraducteur _traducteur;
    private readonly MySettings _mySettings;
    #endregion

    #region Constructeurs
    public SocieteController(ILogger<SocieteController> logger,
                                     ISocieteViewModel service,
                                 ISocieteTraducteur traducteur,
                                 IOptions<MySettings> settings)
    {
       _logger = logger;
      _service = service;
      _traducteur = traducteur;
      _mySettings = settings.Value;
      _logger.LogInformation("SocieteController- constructeur");
    }
  
    #endregion

    #region Actions du controlleur
    /*
    public async Task<IActionResult> Index(string sortOrder, string searchString)
    {
      ViewData["DesignationSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

      _logger.LogInformation("SocieteController-->index");
      _logger.LogInformation("SocieteController-" + _mySettings.ApiBaseUrl);
         var model =await _service.ObtenireListAsync(1);

      if (!String.IsNullOrEmpty(searchString))
      {
        model = model.Where(s => s.Designation.Contains(searchString)
                               || s.Designation.Contains(searchString));
      }

      switch (sortOrder)
      {
        case "name_desc":
          model = model.OrderByDescending(s => s.Designation);
          break;
      }
      return View(model);
      //return View(await students.AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Edit(int? Id)
    {
      _logger.LogInformation("SocieteController-->Edit");
      if (Id == null)
      {
        return NotFound();
      }

      var model = await _service.ObtenireParIdAsync(1);
      if (model == null)
      {
        return NotFound();
      }
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int Id,int id, [Bind("ID,Designation,RaisonSociale")] SocieteRequetteViewModel model)
    {
      _logger.LogInformation("SocieteController-->Edit");
      var result = await _service.ObtenireParIdAsync(1);
      if (ModelState.IsValid)
      {
        try
        {

        }
        catch (System.Exception ex)
        {

          ModelState.AddModelError("", "Unable to save changes. " +
             "Try again, and if the problem persists " +
             "see your system administrator.");
           _logger.LogError("MEthode Edit -->"+ ex.Message);
        }
        return RedirectToAction("Index");
      }

      return View(model);
     
    }

    public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
    {
      if (id == null)
      {
        return NotFound();
      }

      var result = await _service.ObtenireParIdAsync(1);
      if (result == null)
      {
        return NotFound();
      }

      if (saveChangesError.GetValueOrDefault())
      {
        ViewData["ErrorMessage"] =
            "Delete failed. Try again, and if the problem persists " +
            "see your system administrator.";
      }

      return View(result);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var result = await _service.ObtenireParIdAsync(1);
      if (result == null)
      {
        return RedirectToAction(nameof(Index));
      }

      try
      {
        //_context.Students.Remove(student);
        //await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex )
      {
        _logger.LogError("Methode DeleteConfirmed -->" + ex.Message);
        //Log the error (uncomment ex variable name and write a log.)
        return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
      }
    }
*/
    #endregion

  }
}