using Microsoft.AspNetCore.Mvc;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;

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
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {

            return View();
        }
    }
}
