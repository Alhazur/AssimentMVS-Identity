using System;
using System.Collections.Generic;
using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace AssimentMVS_Identity
{
    internal class DbInitializer
    {
        internal static void Initialize(TravelDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            context.Database.EnsureCreated();

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

            //---------------------------------------------------------------------------------

            if (!context.Countries.Any())
            {
                var countries = new List<Country>();
                {
                    countries.Add(new Country() { Name = "Sweden" });
                    countries.Add(new Country() { Name = "Sturbretanien" });
                }
                context.Countries.AddRange(countries);

                context.SaveChanges();

                //if (!context.Cities.Any())
                //{
                //    var cities = new List<City>();
                //    {
                //        cities.Add(new City() { Name = "Alvesta" });
                //        cities.Add(new City() { Name = "London" });
                //    }
                //    context.Cities.AddRange(cities);
                //}

                //context.SaveChanges();
            }

            


        }
    }
}