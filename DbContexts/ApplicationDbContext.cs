using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;

namespace GitHubIdentity.DbContexts
{
    // Last parametre(string) represents the type of primaryKey. its can be change 
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Here We are going to take ConnectionStrings from appsettings.json file
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:Default"]);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}