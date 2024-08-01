using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Models;

namespace RiwiEmplea.Infrastructure.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<AcademicTraining> AcademicTrainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Password)
                    .IsRequired();
                // Configuración adicional para otros campos si es necesario
            });

            modelBuilder.Entity<User>()
                .Property(e => e.State)
                .HasConversion<string>();

            modelBuilder.Entity<Resume>()
                .Property(e => e.State)
                .HasConversion<string>();

            modelBuilder.Entity<Skill>()
                .Property(e => e.State)
                .HasConversion<string>();

            modelBuilder.Entity<Skill>()
                .Property(e => e.Level)
                .HasConversion<string>();

            modelBuilder.Entity<WorkExperience>()
                .Property(e => e.State)
                .HasConversion<string>();

            modelBuilder.Entity<AcademicTraining>()
                .Property(e => e.State)
                .HasConversion<string>();
        }
    }
}
