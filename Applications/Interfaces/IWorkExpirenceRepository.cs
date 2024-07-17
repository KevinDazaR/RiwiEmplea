using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Interfaces.Repositories
{
  public interface IWorkExpirenceRepository
  {
    Task<IEnumerable<WorkExperience>> GetUserWorkExpirenceAsync(int resumeId);
    Task<WorkExperience> AddWorkExpirenceAsync(WorkExperience workExpirence);
    Task<WorkExperience> UpdateWorkExpirenceAsync(int id, WorkExperience workExpirence);
  }
}