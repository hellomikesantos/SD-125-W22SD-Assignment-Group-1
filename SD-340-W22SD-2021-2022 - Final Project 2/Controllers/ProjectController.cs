using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Project Manager")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Project Manager")]
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
            Project? project = _context.Project
                .Include(p => p.Ticket)
                .Include(d => d.Developer)
                .FirstOrDefault(p => p.Id == projectId);

            if (project == null)
            {
                return NotFound();
            }

            List<Ticket> tickets = project.Ticket.ToList();
            List<ApplicationUser> developers = project.Developer.ToList();

            ProjectDetailsViewModel viewModel = new ProjectDetailsViewModel(project, tickets, developers);

            return View(viewModel);
        }
    }
}
