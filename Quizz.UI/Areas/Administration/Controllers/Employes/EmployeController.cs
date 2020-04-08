using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizz.UI.Areas.Administration.Models;
using Quizz.UI.Areas.Administration.LogicVues;
using Quizz.UI.Areas.Administration.Traducteur;
using Quizz.UI.Controllers;
using Quizz.DomainModel.Enums;
using Quizz.UI.Communs.Enum;
using Quizz.DomainModel.Message;
using System.Net;

namespace Quizz.UI.Areas.Administration.controllers.Employe
{
  [Area("Administration")]
 // [AuthorizedAction]
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
        _logger.LogInformation(string.Format(MessageLog.INDEX_MESSAGE, "Index"));
        
      }
      catch (Exception ex)
      {

         ModelState.AddModelError("",string.Format(MessageLog.INDEX_MESSAGE_ERREUR,"Cchargement"));
        _logger.LogWarning(string.Format("Erreur chargement {0}", ex.Message));
      }
      return View(ViewNames.Index);
    }

    public async Task<JsonResult> _chargement(){
      try
      {
        _logger.LogInformation(string.Format(MessageLog.INDEX_MESSAGE, "Index"));
      //  var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

        var societeid = SessionUtilisateur.SocieteId;
        var pageSize = 1;
        var pageCount = 10;
        var model = await  _service.ObtenireListAsync(societeid, pageSize, pageCount);
        
       _logger.LogInformation("Employes--> Index total lignes : " + model.ItemCount);

        return Json(new {  recordsFiltered = model.PageCount, recordsTotal = model.PageSize, data = model.Model });
      }
      catch (Exception ex)
      {
        _logger.LogWarning(string.Format("Erreur chargement {0}", ex.Message));
         return Json(new { recordsFiltered = 0, recordsTotal = 0, data = 0 });
      }

    }

    public async Task<IActionResult> Creation(){
      _logger.LogInformation("SocieteController-->Creation Get");
      EmployeCreationViewModel model = new EmployeCreationViewModel();
      model.EstCompteActif = true;
      model.EstCompteSupprimer = false;
      await Task.FromResult(model);
      return View(ViewNames.Creation, model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Creation([Bind]EmployeCreationViewModel model)
    {
      try
      {
        _logger.LogInformation("SocieteController-->Creation  Post");
        if(ModelState.IsValid){
          model.SocieteId = SessionUtilisateur.SocieteId;
          model.TypeEmployeId =(int)model.TypeEmploye;
          model.CreePar = SessionUtilisateur.Nom;
          var result = await _service.CreationAsync(model);
          if(result.EstErreur)
            throw new Exception(string.Join(";",result.Messages.Select(m => m.Libelle)));
         
          _logger.LogInformation("SocieteController-->Creation  Creation avec reussite. redirection");
          return RedirectToAction(nameof(Index));
        }

      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", string.Format(MessageLog.INDEX_MESSAGE_ERREUR, "Creation"));
        _logger.LogWarning( string.Format("Erreur lors de la creation {0}",ex.Message));
      }
      return View(ViewNames.Creation , model);
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
        model.TypeEmploye = (TypeEmployeEnum)model.TypeEmployeId;
      }
      catch (Exception ex)
      {
        model = new EmployeEditionViewModel();
        ModelState.AddModelError("", string.Format(MessageLog.INDEX_MESSAGE_ERREUR, "Chargement Edit"));
        _logger.LogWarning(string.Format("Erreur lors du chargement {0}", ex.Message));
      }
      return View(ViewNames.Edit , model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([Bind]EmployeEditionViewModel model)
    {
      try
      {
        _logger.LogInformation("SocieteController-->Edit debut misejour");
        

        if (ModelState.IsValid)
        {
          
          if((int)model.TypeEmploye != model.TypeEmployeId)
            model.TypeEmployeId = (int)model.TypeEmploye;

          model.MiseJourPar = SessionUtilisateur.Nom; 

          var result = await _service.ModificationAsync(model);
          if(result.EstErreur)
            throw new Exception(string.Join(";", result.Messages.Select(m => m.Libelle)));

          _logger.LogInformation("SocieteController-->Edit , Misejour Avec Success , Redirection Index");

          return RedirectToAction(nameof(Index));
        }

      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", string.Format(MessageLog.INDEX_MESSAGE_ERREUR, "Modification"));
        _logger.LogWarning(string.Format("Erreur lors de la misejour {0}", ex.Message));
      }
      return View(ViewNames.Edit, model);
    }

    public async Task<IActionResult> Delete(int id, bool? saveChangesError = false)
    {
      EmployeEditionViewModel model = null;
      try
      {
        _logger.LogInformation("SocieteController-->Delete chargement vue suppression");

        var requette = await _service.ObtenireParIdAsync(id);
        if (requette.EstErreur)
          throw new Exception(string.Join(";", requette.Messages.Select(m => m.Libelle)));
        
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
      return View(ViewNames.Delete , model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirme(int id)
    {
      try
      {
        _logger.LogInformation("SocieteController-->Delete debut Suppression");

        var requette = await _service.ObtenireParIdAsync(id);
        var result = await _service.SuppressionAsync(id);
        if (result.EstErreur)
          throw new Exception(string.Join(";", result.Messages.Select(m => m.Libelle)));

        _logger.LogInformation("SocieteController-->Delete fin  Suppression avec success, redirection");
        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex)
      {
        _logger.LogWarning(string.Format("SocieteController-->Delete  ,Erreur lors de la Suppression {0}", ex.Message));

        return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
      }
    }


   
    
    #endregion

  }

}