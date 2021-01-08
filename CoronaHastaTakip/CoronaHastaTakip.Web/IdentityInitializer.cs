using CoronaHastaTakip.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var ekipRole = await roleManager.FindByNameAsync("Ekip");
            if (ekipRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Ekip" });
            }

            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                AppUser user = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    Name = "admin",
                    Surname = "admin",
                };
                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
