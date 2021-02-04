using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApiGitHubProgram.Exts;

using WebApiGitHubProgram.Data;


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

        public DbSet<MyTable> MyTables { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<WebApiGitHubProgram.Data.MyTable> MyTables { get; set; }
        public object Balutable { get; internal set; }
        public DbSet<WebApiGitHubProgram.Data.MyData> MyData { get; set; }

    }
}
