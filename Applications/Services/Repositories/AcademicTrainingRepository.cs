using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories
{
  public class AcademicTrainingRepository: IAcademicTrainingRepository
  {
    private readonly BaseContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UsersRepository> _logger;
    public AcademicTrainingRepository(BaseContext context, IMapper mapper, ILogger<UsersRepository> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<IEnumerable<AcademicTraining>> GetUserAcademicTrainingsAsync(int resumeId)
    {
      return await _context.AcademicTrainings.Where(x => x.ResumeId == resumeId)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<AcademicTraining> AddAcademicTraningAsync(AcademicTraining academicTraining)
    {
      _context.AcademicTrainings.Add(academicTraining);
      await _context.SaveChangesAsync();
      return academicTraining;
    }

    public async Task<AcademicTraining> UpdateAcademicTrainigAsync(int id, AcademicTraining academicTraining)
    {
      academicTraining.Id = id;
      _context.Entry(academicTraining).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return academicTraining;
    }
  }
}