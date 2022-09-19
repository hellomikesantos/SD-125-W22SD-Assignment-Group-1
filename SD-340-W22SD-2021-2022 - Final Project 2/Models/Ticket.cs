using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public enum Priority
    {
        low,
        medium,
        high
    }

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public bool Completed { get; set; }

        [Required]
        [Range(5, 200)]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        public int Hours { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [InverseProperty("Tickets")]
        public virtual ICollection<ApplicationUser> Developers { get; set; } = new HashSet<ApplicationUser>();

        [InverseProperty("OwnedTickets")]
        public virtual ICollection<ApplicationUser> TaskOwners { get; set; } = new HashSet<ApplicationUser>();

        [InverseProperty("WatchedTickets")]
        public virtual ICollection<ApplicationUser> TaskWatchers { get; set; } = new HashSet<ApplicationUser>();
        //public virtual ICollection<Comment> Comment { get; set; } = new HashSet<Comment>();
    }
}
