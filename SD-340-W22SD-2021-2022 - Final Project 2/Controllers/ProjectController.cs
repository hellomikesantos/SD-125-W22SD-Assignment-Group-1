using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;
using SD_340_W22SD_2021_2022___Final_Project_2.Models.ViewModels;


namespace SD_340_W22SD_2021_2022___Final_Project_2.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Project> projects = _context.Project.ToList();
            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            Project project = new Project();

            project.Name = name;
            _context.Project.Add(project);
            _context.SaveChanges();

            return View();
        }

        public IActionResult Details(int projectId)
        {
            Project? project = _context.Project.Include(p => p.ProjectTask).Include(p => p.Developer).FirstOrDefault(p => p.Id == projectId);

            if (project == null)
            {
                return NotFound();
            }

            List<ProjectTask> tasks = project.ProjectTask.ToList();
            List<ApplicationUser> developers = project.Developer.ToList();

            ProjectDetailsViewModel viewModel = new ProjectDetailsViewModel(project, tasks, developers);

            return View(viewModel);
        }
    }
}
