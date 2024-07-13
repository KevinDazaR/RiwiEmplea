using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Dtos.PersonalData;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories.PersonalData.Methods
{
  public class GetPersonalData: IGetPersonalData
  {
    private readonly IUsersRepository _usersRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly IAcademicTrainingRepository _academicTraining;
    private readonly IWorkExpirenceRepository _workExpirenceRepository;
    private readonly ISkillsRepository _skillsRepository;
    public GetPersonalData(
      IUsersRepository usersRepository,
      IResumeRepository resumeRepository,
      IAcademicTrainingRepository academicTrainingRepository,
      IWorkExpirenceRepository workExpirenceRepository,
      ISkillsRepository skillsRepository
    )
    {
      _usersRepository = usersRepository;
      _resumeRepository = resumeRepository;
      _academicTraining = academicTrainingRepository;
      _workExpirenceRepository = workExpirenceRepository;
      _skillsRepository = skillsRepository;
    }
    public async Task<PersonalDataDTO> GetPersonalDataAsync(int userId)
    {

      User user = await _usersRepository.GetUserByIdAsync(userId);

      if(user == null)
        return null;
      
      Resume userResume = await _resumeRepository.GetUserResumeAsync(userId);

      if(userResume == null)
        return UserWithoutResume(user);

      return await GetFullResumeDataAsync(user.Name, userResume);
    }

    public async Task<PersonalDataDTO> GetPersonalDataAsync()
    {
      PersonalDataDTO userInfo = new();
      userInfo.AcademicTrainings = await _academicTraining.GetUserAcademicTrainingsAsync(1);
      return userInfo;
    }

    private PersonalDataDTO UserWithoutResume(User user) 
      => new() { FullName = user.Name };

    private async Task<PersonalDataDTO> GetFullResumeDataAsync(string userName, Resume resume)
    {
      PersonalDataDTO userInfo = new()
      {
        FullName = userName,
        Resume = resume,
        AcademicTrainings = await _academicTraining.GetUserAcademicTrainingsAsync(resume.Id),
        WorkExpirence = await _workExpirenceRepository.GetUserWorkExpirenceAsync(resume.Id),
        Skills = await _skillsRepository.GetUserSkillsAsync(resume.Id)
      };
      return userInfo;
    }
  }
}