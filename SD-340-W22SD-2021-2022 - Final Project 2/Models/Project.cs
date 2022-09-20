using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters long.")]
        [MaxLength(200, ErrorMessage = "Name must be less than or equal to 200 characters.")]
        public string Name { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; } = new HashSet<Ticket>();

        [InverseProperty("Projects")]
        public virtual ICollection<ApplicationUser> Developers { get; set; } = new HashSet<ApplicationUser>();
    }
}
