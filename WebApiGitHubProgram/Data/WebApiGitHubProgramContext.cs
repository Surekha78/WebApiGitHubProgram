using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiGitHubProgram.Data;
using WebApiGitHubProgram.Extension;

namespace WebApiGitHubProgram.Data
{
    public class WebApiGitHubProgramContext : DbContext
    {
        public WebApiGitHubProgramContext (DbContextOptions<WebApiGitHubProgramContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedMyDB();
        }
        public DbSet<WebApiGitHubProgram.Data.MyTable> MyTables { get; set; }

        public DbSet<WebApiGitHubProgram.Data.Customer> Customer { get; set; }

        public DbSet<Job> job { get; set; }
        public DbSet<Employee1> GetEmployee1s { get; set; }


    }
}
