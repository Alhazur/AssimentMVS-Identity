using System;
using AssimentMVS_Identity.DataBase;
using Microsoft.AspNetCore.Identity;

namespace AssimentMVS_Identity
{
    internal class DbInitializer
    {
        internal static void Initialize(TravelDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole("Admin");

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole("NormalUser");

                roleManager.CreateAsync(role).Wait();
            }

            //---------------------------------------------------------------------------------

            if (userManager.FindByNameAsync("Ramzan").Result == null)
            {
                AppUser user = new AppUser();
                user.Email = "ramzan@admin.se";
                user.UserName = "Ramzan";

                var result = userManager.CreateAsync(user, "Password!123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("Alle").Result == null)
            {
                AppUser user = new AppUser();
                user.Email = "alle@mail.se";
                user.UserName = "Alle";

                var result = userManager.CreateAsync(user, "Password!123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }

            //context.SaveChanges();
        }
    }
}