using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories
{
  public class ResumeRepository: IResumeRepository
  {
    private readonly BaseContext _context;
    private readonly IMapper _mapper;
    public ResumeRepository(BaseContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Resume> GetUserResumeAsync(int userId)
    {
      return await _context.Resumes.FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<Resume> AddResumeAsync(Resume resume)
    {
      _context.Resumes.Add(resume);
      await _context.SaveChangesAsync();
      return resume;
    }

    public async Task<Resume> UpdateResumeAsync(int id, Resume resume)
    {
      resume.Id = id;
      _context.Entry(resume).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return resume;
    }

    public async Task<Resume> CreateOrGetResumeAsync(int userId)
    {
      Resume userResume = await GetUserResumeAsync(userId);

      if(userResume == null)
       return await CreateNewResume(userId);

      return userResume;
    }

    private async Task<Resume> CreateNewResume(int userId)
    {
      Resume resume = new()
      {
        UserId = userId,
        CreatedAt = DateTime.Now,
        AboutMy = ""
      };

      return await AddResumeAsync(resume);
    }
  }
}