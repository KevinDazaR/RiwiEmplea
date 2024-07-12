using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Interfaces.Repositories
{
  public interface ISkillsRepository
  {
    Task<IEnumerable<Skill>> GetUserSkillsAsync(int resumeId);
    Task<Skill> AddSkillAsync(Skill skill);
    Task<Skill> UpdateSkillAsync(int id, Skill skill);
  }
}