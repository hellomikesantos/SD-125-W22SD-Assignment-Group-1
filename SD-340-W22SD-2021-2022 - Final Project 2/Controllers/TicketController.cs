using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Controllers
{
    public class TicketController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public TicketController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> Create(int projectId)
        {
            Project? project = await _context.Project.Include(p => p.Developers).FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                return BadRequest();
            }

            return View(project);
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> Create(int projectId, string[] taskOwnerIds, string name = "Do it", int hours = 1, Priority priority = Priority.low)
        {
            if (taskOwnerIds.Count() == 0)
            {
                return RedirectToAction("Create", new { projectId = projectId });
            }

            Ticket ticket = new Ticket();
            ticket.ProjectId = projectId;
            ticket.Name = name;
            ticket.Hours = hours;
            ticket.Priority = priority;
            ticket.Completed = false;
            foreach (String taskOwnerId in taskOwnerIds)
            {
                ApplicationUser dev = await _userManager.FindByIdAsync(taskOwnerId);
                ticket.Developers.Add(dev);
            }


            await _context.Ticket.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Project");
        }
    }
}
