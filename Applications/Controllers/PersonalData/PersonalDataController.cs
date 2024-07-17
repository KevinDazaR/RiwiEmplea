using Microsoft.AspNetCore.Mvc;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Dtos.PersonalData;

namespace RiwiEmplea.Applications.Controllers.PersonalData
{
  [Route("api/personal_data")]
  [ApiController]
  public class PersonalDataController: ControllerBase
  {
    private readonly IPersonalDataService _personalDataService;
    public PersonalDataController(IPersonalDataService personalDataService)
    {
      _personalDataService = personalDataService;
    }

    [HttpGet("{Id}")]
    public async Task<PersonalDataDTO> GetById(int Id)
    {
      return await _personalDataService.GetPersonalDataAsync(Id);
    }
    
  }
}