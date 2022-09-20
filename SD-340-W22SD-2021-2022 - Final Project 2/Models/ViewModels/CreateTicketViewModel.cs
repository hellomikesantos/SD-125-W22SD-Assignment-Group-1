namespace SD_340_W22SD_2021_2022___Final_Project_2.Models.ViewModels
{
    public class CreateTicketViewModel
    {
        public Project Project { get; set; }
        public Ticket Ticket { get; set; }
        public List<ApplicationUser> Developers { get; set; } = new List<ApplicationUser>();

        public CreateTicketViewModel(Project project, Ticket ticket, List<ApplicationUser> developers)
        {
            Project = project;
            Ticket = ticket;
            Developers = developers;
        }
    }
}
