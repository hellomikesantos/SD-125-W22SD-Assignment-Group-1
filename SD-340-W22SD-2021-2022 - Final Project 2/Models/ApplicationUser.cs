using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [InverseProperty("Developers")]
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        [InverseProperty("Developers")]
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

        [InverseProperty("TaskOwners")]
        public virtual ICollection<Ticket> OwnedTickets { get; set; } = new HashSet<Ticket>();

        [InverseProperty("TaskWatchers")]
        public virtual ICollection<Ticket> WatchedTickets { get; set; } = new HashSet<Ticket>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
