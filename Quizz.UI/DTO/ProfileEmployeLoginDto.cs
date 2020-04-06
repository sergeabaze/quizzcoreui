namespace Quizz.UI.DTO
{
  public class ProfileEmployeLoginDto
  {
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int EmployeId { get; set; }
    public ProfileLoginDto Profile { get; set; }
  }

}