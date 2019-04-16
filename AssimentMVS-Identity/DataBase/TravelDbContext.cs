using AssimentMVS_Identity.Models;
using AssimentMVS_Identity.Models.Class;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVS_Identity.DataBase
{
    public class TravelDbContext : IdentityDbContext<AppUser>
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options){ }

        public DbSet<Country> Countries { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
