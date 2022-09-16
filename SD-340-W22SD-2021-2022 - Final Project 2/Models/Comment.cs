using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range (1, 1000)]
        public string Content { get; set; }

        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }
}
