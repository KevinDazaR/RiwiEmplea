using RiwiEmplea.Dtos.PersonalData;

namespace RiwiEmplea.Applications.Interfaces
{
  public interface IPersonalDataService
  {
    string GetPublicUrl();
    Task<PersonalDataDTO> GetPersonalDataAsync();
    Task<PersonalDataDTO> UpdatePersonalDataAsync(PersonalDataDTO userInfo);

    // Temporal just for testing
    Task<PersonalDataDTO> GetPersonalDataAsync(int userId);
  }
}