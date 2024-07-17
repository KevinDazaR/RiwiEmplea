using RiwiEmplea.Dtos.PersonalData;

namespace RiwiEmplea.Applications.Interfaces
{
  public interface IGetPersonalData
  {
    Task<PersonalDataDTO> GetPersonalDataAsync();
    // Temporal just for testing
    Task<PersonalDataDTO> GetPersonalDataAsync(int userId);
  }
}