namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public enum Priority
    {
        low,
        medium,
        high
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Priority Priority { get; set; }

        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }

    
}
