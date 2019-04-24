using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVS_Identity.DataBase;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AssimentMVS_Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();

            using ( var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    RoleManager<IdentityRole> roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
                    UserManager<AppUser> userManager = service.GetRequiredService<UserManager<AppUser>>();

                    var context = service.GetRequiredService<TravelDbContext>();

                    DbInitializer.Initialize(context, roleManager, userManager);
                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
