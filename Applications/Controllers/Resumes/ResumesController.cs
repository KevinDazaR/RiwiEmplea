using Microsoft.AspNetCore.Mvc;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Controllers.Resumes
{
  [Route("api/resume")]
  [ApiController]
  public class ResumesController: ControllerBase
  {
    private readonly IResumeRepository _resumesRepository;
    public ResumesController(IResumeRepository resumesRepository)
    {
      _resumesRepository = resumesRepository;
    }

    [HttpGet("{Id}")]
    public async Task<Resume> GetById(int Id)
    {
      return await _resumesRepository.CreateOrGetResumeAsync(Id);
    }
    
  }
}