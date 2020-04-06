using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quizz.UI.Areas.Administration.LogicVues;
using Quizz.UI.Areas.Administration.Traducteur;
using Quizz.UI.Areas.Administration.TypeClient.LogicVues;
using Quizz.UI.Areas.Administration.TypeClient.Traducteur;
using Quizz.UI.Communs;
using Quizz.UI.Services;

namespace Quizz.UI{
public static class ContainerSetUp
{

  public static void Configuration(this IServiceCollection services){
    ConfigurationLogicVues(services);
    ConfigurationLogicTraducteurs(services);
   // AjoutConfigurations(services,configuration);
  }
  private static void ConfigurationLogicVues(IServiceCollection services){
    
      services.AddTransient<IHttpCustomClientFactory, HttpCustomClientFactory>();
      services.AddTransient<ITypeClientViewModel, TypeClientViewModel>();
      services.AddTransient<ISocieteViewModel, SocieteViewModel>();
      services.AddTransient<IEmployeViewModel, EmployeViewModel>();
      services.AddTransient<IUtilisateurService, UtilisateurService>();
      services.AddTransient<IEmailSender, EmailSender>();
  }

  private static void ConfigurationLogicTraducteurs(IServiceCollection services)
  {
    services.AddScoped<ITypeClientTraducteur, TypeClientTraducteur>();
    services.AddScoped<ISocieteTraducteur, SocieteTraducteur>();
    services.AddScoped<IEmployeTraducteur, EmployeTraducteur>();
  }

  private static void AjoutConfigurations(IServiceCollection services, IConfiguration configuration){


  }

  private static void ConfigureAutoMapper(IServiceCollection services){
    /*var mapperConfig = AutoMapperConfigurator.Configure();
    var mapper = mapperConfig.CreateMapper();
    services.AddSingleton(x => mapper);
    services.AddTransient<IAutoMapper, AutoMapperAdapter>();*/
  }
    
}
}