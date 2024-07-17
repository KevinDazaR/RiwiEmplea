using RiwiEmplea.Dtos.PersonalData;

namespace RiwiEmplea.Applications.Interfaces
{
  public interface IUpdatePersonalData
  {
    Task<PersonalDataDTO> UpdatePersonalDataAsync(PersonalDataDTO userInfo);
  }
}