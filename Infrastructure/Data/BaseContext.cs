using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Models;

namespace RiwiEmplea.Data
{
    public class BaseContext(DbContextOptions<BaseContext> options): DbContext(options)
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<AcademicTrainings> AcademicTraining { get; set; }
    }
}