using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.BLL
{
    public class UserBusinessLogic
    {
        private UserManager<ApplicationUser> _userManager;
        
        public UserBusinessLogic(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ApplicationUser>> GetAllUsersWithoutRoleAsync()
        {
            List<ApplicationUser> usersWithoutRole = new List<ApplicationUser>();
            List<ApplicationUser> users = _userManager.Users.ToList();

            foreach(ApplicationUser user in users)
            {
                List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);

                if(userRoles.Count() == 0)
                {
                    usersWithoutRole.Add(user);
                }
            }

            return usersWithoutRole;
        }

        public async Task AssignUserToARoleAsync(ApplicationUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task <List<string>> GetUserRoles(ApplicationUser user)
        {
            return (List<string>)await _userManager.GetRolesAsync(user);
        }

        public async Task<List<ApplicationUser>> GetAllUsersWithSpecificRoleAsync(string role)
        {
            return (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync(role);
        }

        public ApplicationUser GetUserByUserId(string userId)
        {
            return _userManager.Users.Include(user => user.OwnedTickets).Include(user => user.WatchedTickets).Include(user => user.Tickets).Include(user => user.Projects).First(user => user.Id == userId);
        }

        public async Task<ApplicationUser> GetCurrentUserByNameAsync(string identity)
        {
            ApplicationUser currUser = await _userManager.Users.Include(user => user.OwnedTickets).Include(user => user.WatchedTickets).Include(user => user.Tickets).Include(user => user.Projects).FirstAsync(user => user.UserName == identity);
            return currUser;
        }

    }
}
