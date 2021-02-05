using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Data
{
    public class WebApiGitHubProgramContext : DbContext
    {
        public WebApiGitHubProgramContext (DbContextOptions<WebApiGitHubProgramContext> options)
            : base(options)
        {
        }

        public DbSet<MyTable> MyTables { get; set; }
        public DbSet<Title> Titles { get; set; }

        public DbSet<student> students { get; set; }
        public object GitTable { get; internal set; }
    }
}
