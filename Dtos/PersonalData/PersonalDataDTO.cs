using RiwiEmplea.Dtos.Users;
using RiwiEmplea.Models;

namespace RiwiEmplea.Dtos.PersonalData
{
  public class PersonalDataDTO
  {
    public UsersDTO UsersDTO {get; set;}
    public Resume Resume {get; set;}
    public IEnumerable<Skill>? Skills {get; set;}
    public IEnumerable<WorkExperience>? WorkExpirences {get; set;}
    public IEnumerable<AcademicTraining>? AcademicTrainings {get; set;}
  }
}