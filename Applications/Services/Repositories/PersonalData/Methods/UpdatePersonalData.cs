using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Dtos.PersonalData;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories.PersonalData.Methods
{
  public class UpdatePersonalData: IUpdatePersonalData
  {
    private readonly IUsersRepository _usersRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly IAcademicTrainingRepository _academicTraining;
    private readonly IWorkExpirenceRepository _workExpirenceRepository;
    private readonly ISkillsRepository _skillsRepository;
    public UpdatePersonalData(
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
    public async Task<PersonalDataDTO> UpdatePersonalDataAsync(PersonalDataDTO userInfo)
    {
      await UpdateResume(userInfo.Resume);
      await UpdateAcademicTraining(userInfo.AcademicTrainings.ToList());
      await UpdateSkills(userInfo.Skills.ToList());
      await UpdateWorkExpirences(userInfo.WorkExpirence.ToList());

      return userInfo;
    }

    public async Task UpdateResume(Resume resume)
    {
      if(!IsValidId(resume.Id)) 
      {
        await _resumeRepository.AddResumeAsync(resume);
      }
      else
      {
        await _resumeRepository.UpdateResumeAsync(resume.Id, resume);
      }
    }

    public async Task UpdateAcademicTraining(List<AcademicTraining> academicTrainings)
    {
      foreach(AcademicTraining training in academicTrainings)
      {
        if(!IsValidId(training.Id)) 
        {
          await _academicTraining.AddAcademicTraningAsync(training);
        }
        else
        {
          await _academicTraining.UpdateAcademicTrainigAsync(training.Id, training);
        }
      }
    }

    public async Task UpdateSkills(List<Skill> skills)
    {
      foreach(var skill in skills)
      {
        if(!IsValidId(skill.Id)) 
        {
          await _skillsRepository.AddSkillAsync(skill);
        }
        else
        {
          await _skillsRepository.UpdateSkillAsync(skill.Id, skill);
        }
      }
    }

    public async Task UpdateWorkExpirences(List<WorkExperience> workExperiences)
    {
      foreach(var entry in workExperiences)
      {
        if(!IsValidId(entry.Id)) 
        {
          await _workExpirenceRepository.AddWorkExpirenceAsync(entry);
        }
        else
        {
          await _workExpirenceRepository.UpdateWorkExpirenceAsync(entry.Id, entry);
        }
      }
    }

    private bool IsValidId(int modelId)
    {
      if(modelId == null)
        return false;
      
      if(modelId == 0)
        return false;

      return true;
    }
  }
}