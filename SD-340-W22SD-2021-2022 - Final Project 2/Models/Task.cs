using System.ComponentModel.DataAnnotations;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public enum Priority
    {
        low,
        medium,
        high
    }

    public class ProjectTask
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Required]
        [Range(5, 200)]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        public int Hours { get; set; }
        public Priority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Comment> Comment { get; set; } = new HashSet<Comment>();
        public virtual ICollection<ApplicationUser> Developer { get; set; } = new HashSet<ApplicationUser>();
    }
}
