using Microsoft.AspNetCore.Identity;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Project> Project { get; set; } = new HashSet<Project>();
        //public virtual ICollection<ProjectTask> ProjectTask { get; set; } = new HashSet<ProjectTask>();
    }
}
