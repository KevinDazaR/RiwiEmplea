using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Applications.Services.Repositories.PersonalData.Methods;
using RiwiEmplea.Dtos.PersonalData;
using RiwiEmplea.Dtos.Users;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories.PersonalData
{
  public class PersonalDataService: IPersonalDataService
  {
    // private readonly IUsersRepository _usersRepository;
    // private readonly IResumeRepository _resumeRepository;
    // private readonly IAcademicTrainingRepository _academicTraining;
    // private readonly IWorkExpirenceRepository _workExpirenceRepository;
    // private readonly ISkillsRepository _skillsRepository;
    private readonly IGetPersonalData _getPersonalData;
    private readonly IUpdatePersonalData _updatePersonalData;
    public PersonalDataService(
      // IUsersRepository usersRepository,
      // IResumeRepository resumeRepository,
      // IAcademicTrainingRepository academicTrainingRepository,
      // IWorkExpirenceRepository workExpirenceRepository,
      // ISkillsRepository skillsRepository
      IGetPersonalData getPersonalData,
      IUpdatePersonalData updatePersonalData
    )
    {
      _getPersonalData = getPersonalData;
      _updatePersonalData = updatePersonalData;

      // _usersRepository = usersRepository;
      // _resumeRepository = resumeRepository;
      // _academicTraining = academicTrainingRepository;
      // _workExpirenceRepository = workExpirenceRepository;
      // _skillsRepository = skillsRepository;
    }

    public string GetPublicUrl() => throw new NotImplementedException();

    public async Task<PersonalDataDTO> UpdatePersonalDataAsync(PersonalDataDTO userInfo)
    {
      return await _updatePersonalData.UpdatePersonalDataAsync(userInfo);
    }
    
    public async Task<PersonalDataDTO> GetPersonalDataAsync(int userId)
    {
      return await _getPersonalData.GetPersonalDataAsync(userId);
    }

    public async Task<PersonalDataDTO> GetPersonalDataAsync()
    {
      return await _getPersonalData.GetPersonalDataAsync();
    }
  }
}