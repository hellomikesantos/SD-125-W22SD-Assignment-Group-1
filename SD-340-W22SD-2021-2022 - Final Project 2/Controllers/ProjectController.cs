using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Project Manager, Developer")]
        public IActionResult Index()
        {
            List<Project> projects = _context.Project.Include(p => p.Ticket).OrderBy(p => p.Name).ToList();
            return View(projects);
        }

        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> Create()
        {
            List<ApplicationUser>? developers;
            CreateProjectViewModel vm;
            Project project = new Project();

            try
            {
                developers = (List<ApplicationUser>?)await _userManager.GetUsersInRoleAsync("Developer");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }

            vm = new CreateProjectViewModel(project, developers);

            return View(vm);
        }

        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Ticket, Developers")] Project project, string[] developerIds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                foreach (String developerId in developerIds)
                {
                    ApplicationUser dev = await _userManager.FindByIdAsync(developerId);
                    project.Developers.Add(dev);
                }

                _context.Project.Add(project);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Details(int projectId)
        {
            Project? project = _context.Project
                .Include(p => p.Ticket)
                .ThenInclude(t => t.TaskWatchers)
                .Include(u => u.Developers)
                .ThenInclude(d => d.WatchedTickets)
                .FirstOrDefault(p => p.Id == projectId);

            if (project == null)
            {
                return NotFound();
            }

            List<Ticket> tickets = project.Ticket.ToList();
            List<ApplicationUser> developers = project.Developers.ToList();

            return View(project);
        }
    }
}
