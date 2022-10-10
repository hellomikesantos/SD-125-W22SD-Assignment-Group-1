using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.BLL;
using SD_340_W22SD_2021_2022___Final_Project_2.DAL;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        //private RoleManager<ApplicationUser> _roleManager;
        //Added business logic below here.
        private readonly UserBusinessLogic userBL;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //_context = context;
            _userManager = userManager;
            userBL = new UserBusinessLogic(_userManager);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UnassignedDevelopers()
        {
            //List<string> userIds = _context.UserRoles.Select(ur => ur.UserId).ToList();
            //List<ApplicationUser> users = _context.Users.Where(u => !userIds.Contains(u.Id)).ToList();
            //return View(users);
            List<ApplicationUser> userWithoutRoles = await userBL.GetAllUsersWithoutRoleAsync();
            return View(userWithoutRoles);
        }

        [HttpPost]
        public async Task<IActionResult> AssignDeveloper(string userId)
        {
            ApplicationUser? user = userBL.GetUserByUserId(userId);

            if (user == null)
            {
                return BadRequest();
            }

            await userBL.AssignUserToARoleAsync(user, "Developer");

            return RedirectToAction(nameof(UnassignedDevelopers));
        }

        [HttpPost]
        public async Task<IActionResult> AssignProjectManager(string userId)
        {
            ApplicationUser? user = userBL.GetUserByUserId(userId);

            if (user == null)
            {
                return BadRequest();
            }

            await userBL.AssignUserToARoleAsync(user, "Project Manager");

            return RedirectToAction(nameof(UnassignedDevelopers));
        }
    }
}
