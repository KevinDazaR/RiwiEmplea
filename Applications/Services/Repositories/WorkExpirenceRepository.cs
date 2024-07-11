using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories
{
  public class WorkExpirenceRepository: IWorkExpirenceRepository
  {
    private readonly BaseContext _context;
    private readonly IMapper _mapper;
    public WorkExpirenceRepository(BaseContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<WorkExperience>> GetUserWorkExpirenceAsync(int resumeId)
    {
      return await _context.WorkExperiences.Where(x => x.ResumeId == resumeId)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<WorkExperience> AddWorkExpirenceAsync(WorkExperience workExperience)
    {
      _context.WorkExperiences.Add(workExperience);
      await _context.SaveChangesAsync();
      return workExperience;
    }

    public async Task<WorkExperience> UpdateWorkExpirenceAsync(int id, WorkExperience workExperience)
    {
      workExperience.Id = id;
      _context.Entry(workExperience).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return workExperience;
    }
  }
}