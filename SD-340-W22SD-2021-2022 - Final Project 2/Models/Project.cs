using System.ComponentModel.DataAnnotations;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range (5, 200)]
        public string Name { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; } = new HashSet<Ticket>();
        public virtual ICollection<ApplicationUser> User { get; set; } = new HashSet<ApplicationUser>();
    }
}
