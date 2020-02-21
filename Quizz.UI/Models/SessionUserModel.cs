namespace Quizz.UI.Models
{
  public class SessionUserModel
  {
    public string Email { get; set; }
    public string Nom { get; set; }
    public string Login { get; set; }
    public string ID { get; set; }
    public SessionUserModel(){}
    public SessionUserModel(SessionUserModel _model){
      this.Email = _model.Email ;
      this.Nom = _model.Nom;
      this.Login = _model.Login;
      this.ID = _model.ID;
    }
      
  }
}