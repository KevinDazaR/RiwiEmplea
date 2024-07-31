using RiwiEmplea.Models.Enums;

namespace RiwiEmplea.Models
{
  public class User
  {
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int GoogleId { get; set; }
    public StateEnum State { get; set; }
    public int? RoleId { get; set; }
  }
}