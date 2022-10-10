using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;
using SD_340_W22SD_2021_2022___Final_Project_2.Models.ViewModels;
using SD_340_W22SD_2021_2022___Final_Project_2.BLL;
using SD_340_W22SD_2021_2022___Final_Project_2.DAL;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        //Added business logic below here.
        private readonly ProjectBusinessLogic projectBL;
        private readonly UserBusinessLogic userBL;

        public ProjectController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            projectBL = new ProjectBusinessLogic(new ProjectRepository(context), _userManager);
            userBL = new UserBusinessLogic(_userManager);
        }

        [Authorize(Roles = "Project Manager, Developer")]
        public async Task<IActionResult> Index(string? hours, string? priority, bool? completed)
        {
            List<Project>? projects = null;

            try
            {
                ApplicationUser user = await userBL.GetCurrentUserByNameAsync(User.Identity.Name);
                //List<string> roles = (List<String>)await _userManager.GetRolesAsync(user);
                List<string> roles = await userBL.GetUserRoles(user);
                string role = roles.Find(r => r.Equals("Developer"));

                if (role == null)
                {
                    role = roles.Find(r => r.Equals("Project Manager"));
                }

                if (role.Equals("Developer"))
                {
                    //    projects = _context.Project
                    //        .Include(p => p.Ticket)
                    //        .Include(d => d.Developers)
                    //        .Where(p => p.Developers.Any(p => p.Id.Equals(user.Id)))
                    //        .OrderBy(p => p.Name).ToList();
                    projects = await projectBL.GetAllProjectsByDeveloperAsync(user.Id);
                }

                if (role.Equals("Project Manager"))
                {
                    //projects = _context.Project
                    //    .Include(p => p.Ticket)
                    //    .OrderBy(p => p.Name)
                    //    .ToList();

                    projects = projectBL.GetAllProjects();
                }

                //No Database call start here
                if (hours == "asc")
                {
                    projects.ForEach(p =>
                    {
                        p.Ticket = p.Ticket.OrderBy(t => t.Hours).ToList();
                    });
                }
                else if (hours == "desc")
                {
                    projects.ForEach(p =>
                    {
                        p.Ticket = p.Ticket.OrderByDescending(t => t.Hours).ToList();
                    });
                }
                else if (priority == "asc")
                {
                    projects.ForEach(p =>
                    {
                        p.Ticket = p.Ticket.OrderBy(t => t.Priority).ToList();
                    });
                }
                else if (priority == "desc")
                {
                    projects.ForEach(p =>
                    {
                        p.Ticket = p.Ticket.OrderByDescending(t => t.Priority).ToList();
                    });
                }
                //No Database call ends here

                if (completed == true)
                {
                    projects.ForEach(p =>
                    {
                        //Michael Ticket GetCompletedTickets BL
                        p.Ticket = p.Ticket.Where(t => t.Completed == true).ToList();
                    });
                } else if (completed == false)
                {
                    projects.ForEach(p =>
                    {
                        //Michael Ticket GetIncompletedTicketList BL
                        p.Ticket = p.Ticket.Where(t => t.Completed == false).ToList();
                    });
                }
               
                return View(projects);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> Create()
        {
            List<ApplicationUser>? developers;
            CreateProjectViewModel vm;
            Project project = new Project();

            try
            {
                //User Business logic get users by role dev
                //developers = (List<ApplicationUser>?)await _userManager.GetUsersInRoleAsync("Developer");
                developers = await userBL.GetAllUsersWithSpecificRoleAsync("Developer");
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
                    //User Business Logic. Get developer by id
                    //ApplicationUser dev = await _userManager.FindByIdAsync(developerId);
                    ApplicationUser dev = userBL.GetUserByUserId(developerId);
                    //Check this if it should be on project BL
                    project.Developers.Add(dev);
                }

                
                //_context.Project.Add(project);
                projectBL.CreateProject(project);

                //_context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Details(int projectId)
        {
            //Project? project = _context.Project
            //    .Include(p => p.Ticket)
            //    .ThenInclude(t => t.TaskWatchers)
            //    .Include(u => u.Developers)
            //    .ThenInclude(d => d.WatchedTickets)
            //    .FirstOrDefault(p => p.Id == projectId);

            Project project = projectBL.GetProjectDetails(projectId);

            if (project == null)
            {
                return NotFound();
            }

            //This should be refactored or not?
            //Ticket BL is needed here
            List<Ticket> tickets = project.Ticket.ToList();
            //User BL is needed here
            List<ApplicationUser> developers = project.Developers.ToList();

            return View(project);
        }
    }
}
