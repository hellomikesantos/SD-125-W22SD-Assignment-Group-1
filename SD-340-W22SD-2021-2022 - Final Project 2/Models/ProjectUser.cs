namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class ProjectUser
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public Project Project { get; set; }
        public ApplicationUser User { get; set; }
    }
}
