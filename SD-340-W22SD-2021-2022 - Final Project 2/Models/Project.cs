namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Task { get; set; } = new HashSet<Task>();
    }
}
