
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Interfaces.Repositories
{
  public interface IResumeRepository
  {
    Task<Resume> GetUserResumeAsync(int userId);
    Task<Resume> CreateOrGetResumeAsync(int userId);
    Task<Resume> AddResumeAsync(Resume resumeDTO);
    Task<Resume> UpdateResumeAsync(int id, Resume resumeDTO);
  }
}