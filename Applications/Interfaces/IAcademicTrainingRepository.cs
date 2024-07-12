using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Interfaces.Repositories
{
  public interface IAcademicTrainingRepository
  {
    Task<IEnumerable<AcademicTraining>> GetUserAcademicTrainingsAsync(int userId);
    Task<AcademicTraining> AddAcademicTraningAsync(AcademicTraining training);
    Task<AcademicTraining> UpdateAcademicTrainigAsync(int id, AcademicTraining training);
  }
}