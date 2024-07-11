using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories
{
  public class SkillsRepository: ISkillsRepository
  {
    private readonly BaseContext _context;
    private readonly IMapper _mapper;
    public SkillsRepository(BaseContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<Skill>> GetUserSkillsAsync(int resumeId)
    {
      return await _context.Skills.Where(x => x.ResumeId == resumeId)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<Skill> AddSkillAsync(Skill skill)
    {
      _context.Skills.Add(skill);
      await _context.SaveChangesAsync();
      return skill;
    }

    public async Task<Skill> UpdateSkillAsync(int id, Skill skill)
    {
      skill.Id = id;
      _context.Entry(skill).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return skill;
    }
  }
}