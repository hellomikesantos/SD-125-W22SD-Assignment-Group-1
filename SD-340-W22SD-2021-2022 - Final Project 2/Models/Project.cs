using System.ComponentModel.DataAnnotations;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [Range (5, 200)]
        public string Name { get; set; }
        public virtual ICollection<ProjectTask> ProjectTask { get; set; } = new HashSet<ProjectTask>();
        public virtual ICollection<ApplicationUser> Developer { get; set; } = new HashSet<ApplicationUser>();
        public virtual ApplicationUser ProjectManager { get; set; } = null!;
    }
}
