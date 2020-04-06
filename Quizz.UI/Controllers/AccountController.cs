using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Quizz.UI.Models;
using Quizz.UI.Models.ComptesViewModel;
using Quizz.UI.Services;

namespace Quizz.UI.Controllers
{


  //[Authorize]
  // [Route("[controller]/[action]")]
  [Route("account")]
  public class AccountController : Controller
  {
    string SessionKey = "userconnect";
    private readonly IUtilisateurService _service;
    private readonly IEmailSender _emailSender;
    private readonly ILogger _logger;

    public AccountController(
        IEmailSender emailSender,
        ILogger<AccountController> logger,
        IUtilisateurService service)
    {
      _service = service;
      _emailSender = emailSender;
      _logger = logger;
    }

    [TempData]
    public string ErrorMessage { get; set; }

     [HttpGet]
    [AllowAnonymous]
    [Route("login")]
    public  async Task<IActionResult> Login(string returnUrl = null)
    {
     
      await Task.FromResult(new { idSession =SessionKey });
      HttpContext.Session.Remove(SessionKey);
      ViewData["ReturnUrl"] = returnUrl;
      return View();
    }

    [Route("login")]
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
      ViewData["ReturnUrl"] = returnUrl;
      _logger.LogInformation("Login debut connection"+ model);
      
     /* model.Email ="admin@gmail.com";
      model.RememberMe =true;
      SessionUserModel user =new SessionUserModel();
      user.Email = model.Email;
      user.Email = model.Email;
      user.Login = "admin.admin";
      user.ID = "admin";
      SessionKey = "userconnect";
      HttpContext.Session.Set<SessionUserModel>(SessionKey,user);
      HttpContext.Session.SetString("email",user.Email);*/
    
     // 
      if (ModelState.IsValid)
      {
        model.EstEmploye =true;
        try
        {
          var reponse = await _service.EmployeLogin(model);
          if (reponse != null)
          {
            _logger.LogInformation("Login debut connection Requette reussite" );

            if(reponse.Model == null){
              _logger.LogError("Pas de données chargées");
                throw new Exception("Pas de données chargées");

            }
            _logger.LogInformation("Login Nodel charger");

            if (reponse.Model.ProfileEmployes == null || reponse.Model.ProfileEmployes.Count <= 0)
            {
              throw new Exception("Pas de Profile pour cette utilisateur");
            }
              
            
            HttpContext.Session.Set<UtilisateurViewModel>(SessionKey, reponse.Model);
            HttpContext.Session.SetString("email", model.Email);
            return RedirectToLocal(returnUrl);

          }
          else
          {
            throw new Exception("Incorrect login");
          }
        }
        catch (Exception ex)
        {

          ModelState.AddModelError(string.Empty, ex.Message);
          return View(model);
        }
        
            

            
        
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        // var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
          /* if (result.Succeeded)
           {
             _logger.LogInformation("User logged in.");
             return RedirectToLocal(returnUrl);
           }
           if (result.RequiresTwoFactor)
           {
             return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
           }
           if (result.IsLockedOut)
           {
             _logger.LogWarning("User account locked out.");
             return RedirectToAction(nameof(Lockout));
           }
           else
           {
             ModelState.AddModelError(string.Empty, "Invalid login attempt.");
             return View(model);
           }*/
        }
        else
        {
          ModelState.AddModelError(string.Empty, "Invalid login attempt.");
          return View(model);
      }

      // If we got this far, something failed, redisplay form
     // return View(model);
    }

    [Route("logout")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
      await Task.FromResult(new { idSession = SessionKey });
      HttpContext.Session.Remove("userconnect");
      _logger.LogInformation("User logged out.");
      return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult ExternalLogin(string provider, string returnUrl = null)
    {
      // Request a redirect to the external login provider.
     // var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
    // var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
    //  return Challenge(properties, provider);
      return null;
    }

   /* [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    {
      if (userId == null || code == null)
      {
        return RedirectToAction(nameof(HomeController.Index), "Home");
      }
      var user = await _userManager.FindByIdAsync(userId);
      if (user == null)
      {
        throw new ApplicationException($"Unable to load user with ID '{userId}'.");
      }
      var result = await _userManager.ConfirmEmailAsync(user, code);
      return View(result.Succeeded ? "ConfirmEmail" : "Error");
    }
*/
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword()
    {
      return View();
    }
/*
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
        {
          // Don't reveal that the user does not exist or is not confirmed
          return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        // For more information on how to enable account confirmation and password reset please
        // visit https://go.microsoft.com/fwlink/?LinkID=532713
       /* var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
        await _emailSender.SendEmailAsync(model.Email, "Reset Password",
           $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");*/
       /* return RedirectToAction(nameof(ForgotPasswordConfirmation));
      }

      // If we got this far, something failed, redisplay form
      return View(model);
    }*/

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPasswordConfirmation()
    {
      return View();
    }

   /* [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword(string code = null)
    {
      if (code == null)
      {
        throw new ApplicationException("A code must be supplied for password reset.");
      }
      var model = new ResetPasswordViewModel { Code = code };
      return View(model);
    }*/

   /* [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var user = await _userManager.FindByEmailAsync(model.Email);
      if (user == null)
      {
        // Don't reveal that the user does not exist
        return RedirectToAction(nameof(ResetPasswordConfirmation));
      }
      var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction(nameof(ResetPasswordConfirmation));
      }
      AddErrors(result);
      return View();
    }*/

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPasswordConfirmation()
    {
      return View();
    }


    [HttpGet]
    public IActionResult AccessDenied()
    {
      return View();
    }

    #region Helpers

   /* private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError(string.Empty, error.Description);
      }
    }
*/
    private IActionResult RedirectToLocal(string returnUrl)
    {
      if (Url.IsLocalUrl(returnUrl))
      {
        return Redirect(returnUrl);
      }
      else
      {
        return RedirectToAction(nameof(HomeController.Index), "Home");
      }
    }

    #endregion

  }
}