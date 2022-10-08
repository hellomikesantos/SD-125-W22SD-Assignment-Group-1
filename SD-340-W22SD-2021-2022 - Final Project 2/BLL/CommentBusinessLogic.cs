using Microsoft.AspNetCore.Identity;
using SD_340_W22SD_2021_2022___Final_Project_2.DAL;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.BLL
{
    public class CommentBusinessLogic
    {
        private IRepository<Comment> repo;
        private readonly UserManager<ApplicationUser> _userManager;
        public CommentBusinessLogic(IRepository<Comment> repo, UserManager<ApplicationUser> userManager)
        {
            this.repo = repo;
            _userManager = userManager;
        }
    }
}
