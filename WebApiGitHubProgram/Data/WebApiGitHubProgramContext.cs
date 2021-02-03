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

        public DbSet<WebApiGitHubProgram.Data.MyTable> MyTables { get; set; }
        public object Balutable { get; internal set; }
        public DbSet<WebApiGitHubProgram.Data.MyData> MyData { get; set; }
    }
}
