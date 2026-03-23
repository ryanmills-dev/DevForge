using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Data
{
    public class DevForgeDbContext : DbContext
    {
        public DevForgeDbContext(DbContextOptions<DevForgeDbContext> options) : base(options)
        {
        }  
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ProjectLanguage> ProjectLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectLanguage>()
                .HasKey(pl => new { pl.ProjectId, pl.LanguageId });
        }
    }
}
