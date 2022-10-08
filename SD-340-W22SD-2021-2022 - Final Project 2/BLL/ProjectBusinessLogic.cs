using Microsoft.AspNetCore.Identity;
using SD_340_W22SD_2021_2022___Final_Project_2.DAL;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.BLL
{
    public class ProjectBusinessLogic
    {
        private IRepository<Project> repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectBusinessLogic(IRepository<Project> repo, UserManager<ApplicationUser> userManager)
        {
            this.repo = repo;
            this._userManager = userManager;
        }

        public async Task<List<Project>> GetAllProjectsByDeveloperAsync(string devId)
        {
            ApplicationUser currUser = await _userManager.FindByIdAsync(devId);
            return repo.GetList(project => project.Developers.Contains(currUser)).ToList();
        }

        public List<Project> GetAllProjects()
        {
            return repo.GetAll().ToList();
        }

        public Project GetProjectDetails(int projId)
        {
            return repo.Get(projId);
        }

        public void CreateProject(Project project)
        {
            repo.Create(project);
            repo.Save();
        }

    }
}
