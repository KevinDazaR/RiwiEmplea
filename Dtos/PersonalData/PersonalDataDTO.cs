using RiwiEmplea.Models;

namespace RiwiEmplea.Dtos.PersonalData
{
  public class PersonalDataDTO
  {
    public string FullName {get; set;}
    public Resume Resume {get; set;}
    public IEnumerable<Skill>? Skills {get; set;}
    public IEnumerable<WorkExperience>? WorkExpirence {get; set;}
    public IEnumerable<AcademicTraining>? AcademicTrainings {get; set;}
  }
}