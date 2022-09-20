namespace SD_340_W22SD_2021_2022___Final_Project_2.Models.ViewModels
{
    public class CreateProjectViewModel
    {
        public Project Project { get; set; }
        public List<ApplicationUser> Developers { get; set; } = new List<ApplicationUser>();    

        public CreateProjectViewModel(Project project, List<ApplicationUser> developers)
        {
            Project = project;
            Developers = developers;
        }
    }
}
