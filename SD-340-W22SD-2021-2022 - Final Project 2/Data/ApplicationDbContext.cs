using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(p => p.Projects)
                .WithOne(u => u.ProjectManager)
                .HasForeignKey(p => p.ProjectManagerId);
        }

        //public DbSet<Comment> Comment { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}