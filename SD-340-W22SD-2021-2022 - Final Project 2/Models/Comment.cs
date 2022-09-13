using System.ComponentModel.DataAnnotations;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        [Range (1, 1000)]
        public string Content { get; set; }
        public virtual ProjectTask ProjectTask { get; set; }
    }
}
