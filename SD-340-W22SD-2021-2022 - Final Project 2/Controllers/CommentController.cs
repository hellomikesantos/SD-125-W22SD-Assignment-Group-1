using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;
using SD_340_W22SD_2021_2022___Final_Project_2.Models.ViewModels;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CommentsForTask(int ticketId)
        {
            ViewBag.ticketId = ticketId;
            CreateCommentViewModel vm;
            List<Comment>? comments;
            Comment newComment = new Comment();

            try
            {
                comments = _context.Comment
                    .Include(u => u.User)
                    .Where(c => c.TicketId == ticketId)
                    .ToList();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Project");
            }

            vm = new CreateCommentViewModel(comments, newComment);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int ticketId, string content)
        {
            return View();
        }
    }
}
