using Library.Domain.Entity;
using Library.Domain.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class SeedRoles
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if(!await roleManager.RoleExistsAsync(UserLevel.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserLevel.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserLevel.Moderator))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserLevel.Moderator));
                }
                if (!await roleManager.RoleExistsAsync(UserLevel.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserLevel.User));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "beqa.basiladze@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "Beqa",
                        LastName = "Basiladze",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        PhoneNumber = "571808508",
                        PhoneNumberConfirmed = true,
                        CreatedAt = DateTime.Now
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin1234@?");
                    await userManager.AddToRoleAsync(newAdminUser, UserLevel.Admin);
                }
            }
        }
    }
}
