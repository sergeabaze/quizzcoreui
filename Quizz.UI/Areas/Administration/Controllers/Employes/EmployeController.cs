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
using Microsoft.AspNetCore.Routing;

namespace Quizz.UI.Areas.Administration.controllers.Employe
{
  [Area("Administration")]
  [AuthorizedAction]
  public class EmployeController : BaseController
  {
    #region Proprietes
    private readonly ILogger<EmployeController> _logger;
    private readonly IEmployeViewModel _service;
    private readonly IEmployeTraducteur _traducteur;
    #endregion

    #region Constructeurs
    public EmployeController(ILogger<EmployeController> logger,
                                     IEmployeViewModel service,
                                     IEmployeTraducteur traducteur)
    {
      _logger = logger;
      _service = service;
      _traducteur = traducteur;
      _logger.LogInformation("EmployeController");
    }

    #endregion
    #region Actions du controlleur
    public IActionResult Index()
    {
      try
      {
        _logger.LogInformation("Employes--> Index");
       /* var societeid = SessionUtilisateur.SocieteId;
        var pageSize = 1;
        var pageCount = 10;
        var model = await _service.ObtenireListAsync(societeid,pageSize,pageCount);
        _logger.LogInformation("Employes--> Index total lignes : " + model.ItemCount );*/

        return View();
      }
      catch (System.Exception)
      {
          
          throw;
      }
     
      //return View(await students.AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> _chargement(){
      try
      {
        _logger.LogInformation("Employes--> Index");
      //  var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

        // Skip number of Rows count  
       // var start = Request.Form["start"].FirstOrDefault();

        // Paging Length 10,20  
       // var length = Request.Form["length"].FirstOrDefault();

        // Sort Column Name  
       // var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

        // Sort Column Direction (asc, desc)  
       // var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

        // Search Value from (Search box)  
       // var searchValue = Request.Form["search[value]"].FirstOrDefault();
        //int _pageSize = length != null ? Convert.ToInt32(length) : 0;
       // int _skip = start != null ? Convert.ToInt32(start) : 0;
        //int recordsTotal = 0;
       // if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
       // {
         // customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
      //  }
        //Search  
       // if (!string.IsNullOrEmpty(searchValue))
       // {
         // customerData = customerData.Where(m => m.Name == searchValue);
       // }


        var societeid = SessionUtilisateur.SocieteId;
        var pageSize = 1;
        var pageCount = 10;
        var model = await  _service.ObtenireListAsync(societeid, pageSize, pageCount);
       // _logger.LogInformation("Employes--> Index total lignes : " + model.ItemCount);

        return Json(new {  recordsFiltered = model.PageCount, recordsTotal = model.PageSize, data = model.Model });
      }
      catch (System.Exception)
      {

        throw;
      }

    }
    public async Task<IActionResult> Creation(){
      _logger.LogInformation("SocieteController-->Creation Get");
      EmployeCreationViewModel model = new EmployeCreationViewModel();
      await Task.FromResult(model);
      return View("Creation",model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Creation([Bind]EmployeCreationViewModel model)
    {
      try
      {
        _logger.LogInformation("SocieteController-->Creation  effective");
        //if(ModelState.IsValid){
           await Task.FromResult(model);
        _logger.LogInformation("SocieteController-->Creation  redirection");
          return RedirectToAction(nameof(Index));
       // }

      }
      catch (Exception ex)
      {

        ModelState.AddModelError("", "Creation impossible. " +
          "merci dessayer de nouveau, et si le probleme persiste " +
          "contactez l'administrateur.");
        _logger.LogWarning( string.Format("Erreur lors de la creation {0}",ex.Message));
      }
      return View(model);
    }


    public async Task<IActionResult> Edit(int id)
    {
      _logger.LogInformation("SocieteController-->Edit Get");
      EmployeEditionViewModel model = null;
      try
      {
        var requette = await _service.ObtenireParIdAsync(id);
        if (requette.EstErreur)
        {
          throw new Exception(string.Join(";", requette.Messages.Select(m=>m.Libelle)));
        }
        

        model = _traducteur.TraduitVersViewModel(requette.Model);
        //return View("Edit", model);
      }
      catch (Exception ex)
      {
        model = new EmployeEditionViewModel();
        ModelState.AddModelError("", "Erreur lors du chargement " + ex.Message);
        _logger.LogWarning(string.Format("Erreur lors du chargement {0}", ex.Message));
      }
        
        
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([Bind]EmployeEditionViewModel model)
    {
      try
      {
        _logger.LogInformation("SocieteController-->Edit Post");
        await Task.FromResult(model);
        //if(ModelState.IsValid){
        return RedirectToAction(nameof(Index));
          
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", "Modification impossible. " +
          "merci dessayer de nouveau, et si le probleme persiste " +
          "contactez l'administrateur.");

        _logger.LogWarning(string.Format("Erreur lors de la misejour {0}", ex.Message));
      }
      return View(model);
    }

    public async Task<IActionResult> Delete(int id, bool? saveChangesError = false)
    {
      EmployeEditionViewModel model = null;
      try
      {
        var requette = await _service.ObtenireParIdAsync(id);
       // await Task.FromResult(1);
        if (requette.EstErreur)
        {
          throw new Exception(string.Join(";", requette.Messages.Select(m => m.Libelle)));
        }
        model = _traducteur.TraduitVersViewModel(requette.Model);

        if (saveChangesError.GetValueOrDefault())
        {
          throw new Exception("Erreur de suppression");
        }

        
      }
      catch (Exception ex)
      {

        ViewData["ErrorMessage"] =
          "Echec Suppression. Try again, and if the problem persists " +
          "see your system administrator." + ex.Message;
        model = new EmployeEditionViewModel();
      }
      return View("Delete", model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirme(int id)
    {
      try
      {
        var requette = await _service.ObtenireParIdAsync(id);

        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex)
      {
        _logger.LogWarning(string.Format("Erreur lors de la misejour {0}", ex.Message));

        return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
      }
    }


   
    
    #endregion

  }

}