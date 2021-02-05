using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Data;


namespace WebApiGitHubProgram.Extension
{
    public static class ExtMethods
    {
        public static void SeedMyDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData
                    (
                        new { id = -1, JobDescription = "HR......" },
                        new { id = -2, JobDescription = "Admin." },
                        new { id = -3, JobDescription = "Dev." },
                          new { id = -4, JobDescription = "Hr." }
                    );
        }


    }
}
