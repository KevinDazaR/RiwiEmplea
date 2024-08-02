using AutoMapper;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Dtos.PersonalData;
using RiwiEmplea.Dtos.Users;
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
    private readonly IMapper _mapper;

    public GetPersonalData(
      IUsersRepository usersRepository,
      IResumeRepository resumeRepository,
      IAcademicTrainingRepository academicTrainingRepository,
      IWorkExpirenceRepository workExpirenceRepository,
      ISkillsRepository skillsRepository,
      IMapper mapper
    )
    {
      _usersRepository = usersRepository;
      _resumeRepository = resumeRepository;
      _academicTraining = academicTrainingRepository;
      _workExpirenceRepository = workExpirenceRepository;
      _skillsRepository = skillsRepository;
      _mapper = mapper;
    }
    public async Task<PersonalDataDTO> GetPersonalDataAsync(int userId)
    {

      User user = await _usersRepository.GetUserByIdAsync(userId);

      UsersDTO userDTO = _mapper.Map<UsersDTO>(user);

      if(user == null)
        return null;
      
      Resume userResume = await _resumeRepository.GetUserResumeAsync(userId);

      if(userResume == null)
        return UserWithoutResume(userDTO);

      return await GetFullResumeDataAsync(userDTO, userResume);
    }

    public async Task<PersonalDataDTO> GetPersonalDataAsync()
    {
      PersonalDataDTO userInfo = new();
      userInfo.AcademicTrainings = await _academicTraining.GetUserAcademicTrainingsAsync(1);
      return userInfo;
    }

    private PersonalDataDTO UserWithoutResume(UsersDTO user) 
      => new() { UsersDTO = user };

    private async Task<PersonalDataDTO> GetFullResumeDataAsync(UsersDTO user, Resume resume)
    {
      PersonalDataDTO userInfo = new()
      {
        UsersDTO = user,
        Resume = resume,
        AcademicTrainings = await _academicTraining.GetUserAcademicTrainingsAsync(resume.Id),
        WorkExpirences = await _workExpirenceRepository.GetUserWorkExpirenceAsync(resume.Id),
        Skills = await _skillsRepository.GetUserSkillsAsync(resume.Id)
      };
      return userInfo;
    }
  }
}