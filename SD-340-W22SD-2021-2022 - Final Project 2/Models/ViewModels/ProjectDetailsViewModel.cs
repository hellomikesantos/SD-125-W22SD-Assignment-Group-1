namespace SD_340_W22SD_2021_2022___Final_Project_2.Models.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public Project Project { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<ApplicationUser> Developers { get; set; }

        public ProjectDetailsViewModel(Project project, List<Ticket> tickets, List<ApplicationUser> developers)
        {
            Project = project;
            Tickets = tickets;
            Developers = developers;
        }
    }
}
