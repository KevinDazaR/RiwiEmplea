using Microsoft.AspNetCore.Mvc;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Dtos.PersonalData;

namespace RiwiEmplea.Applications.Controllers.PersonalData
{
  [Route("api/personal_data")]
  [ApiController]
  public class PersonalDataUpdateController: ControllerBase
  {
    private readonly IPersonalDataService _personalDataService;
    public PersonalDataUpdateController(IPersonalDataService personalDataService)
    {
      _personalDataService = personalDataService;
    }

    [HttpPost]
    public async Task<PersonalDataDTO> UpdateOrAdd(PersonalDataDTO personalData)
    {
      return await _personalDataService.UpdatePersonalDataAsync(personalData);
    }
  }
}