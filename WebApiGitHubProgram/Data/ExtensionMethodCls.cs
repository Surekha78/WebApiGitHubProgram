using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Data
{
    public class ExtensionMethodCls
    {
        public static void SeedMyDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData
                    (
                        new { id = -1, TitleDescription = "Mrs......" },
                        new { id = -2, TitleDescription = "Miss." },
                        new { id = -3, TitleDescription = "Mr." }
                    );
        }
    }
}
