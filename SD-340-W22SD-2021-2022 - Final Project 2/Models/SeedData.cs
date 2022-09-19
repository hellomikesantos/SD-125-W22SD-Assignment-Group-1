using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;

namespace SD_340_W22SD_2021_2022___Final_Project_2.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            List<string> roles = new List<string>
            {
                "Admin", "Project Manager", "Developer"
            };    

            foreach (string role in roles)
            {
                var identityRole = new IdentityRole(role);

                if (!context.Roles.Contains(identityRole))
                {
                    await roleManager.CreateAsync(identityRole);
                }
            }

            if (context.Users.FirstOrDefault(u => u.UserName == "admin@admin.com") == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",

                };
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "abcD1234!");
                user.PasswordHash = hashed;
                user.EmailConfirmed = true;

                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "Admin");

            }

            await context.SaveChangesAsync();
        }
    }
}
