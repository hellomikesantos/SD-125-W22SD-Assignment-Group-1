using Microsoft.AspNetCore.Mvc;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int projectId, string name, int hours, Priority priority)
        {
            ProjectTask task = new ProjectTask();
            task.ProjectId = projectId;
            task.Name = name;
            task.Hours = hours;
            task.Priority = priority;

            _context.ProjectTask.Add(task);
            _context.SaveChanges();

            return RedirectToAction("Details", "Project", new { projectId = projectId });
        }
    }
}
