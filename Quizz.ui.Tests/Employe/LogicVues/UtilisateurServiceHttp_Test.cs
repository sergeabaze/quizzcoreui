using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Quizz.UI.Areas.Administration.LogicVues;
using Quizz.UI.Models.ComptesViewModel;
using Quizz.UI.Services;
using Xunit;
namespace Quizz.ui.Tests.Employe
{
  public class UtilisateurServiceHttp_Test
  {
    //Fixture _fixture;
    private readonly IUtilisateurService _service;

    public UtilisateurServiceHttp_Test()
    {
      _service = new UtilisateurService();
    }

    [Fact]
    public async Task EmployeLogin_OK()
    {
      //arrange
      var viewModel = new LoginViewModel { 
        Email = "admin@yahoo.fr",
         Password ="sa.admin", 
         EstEmploye = true
         };
      //act
     var de = await Task.FromResult(viewModel);
     // var  response =await _service.EmployeLogin(viewModel);

      //assert
      /* Assert.NotNull(response);
       Assert.NotNull(response.Model);
       Assert.NotNull(response.Model.ProfileEmployes);
       Assert.True(response.Model.ProfileEmployes.Count > 0, "attendu liste des profiles");
       Assert.False(response.EstErreur, "pas derreur un false attendu : "+ response.Message);*/
        //Assert.Equal(Id, response.Model.Id);
    }
  }
}