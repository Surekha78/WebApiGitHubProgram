using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Exts
{
    public static class ExtMethods
    {
        public static void SeedMyDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>().HasData
                    (
                        new { id = -1, TitleDescription = "Mrs......" },
                        new { id = -2, TitleDescription = "Miss." },
                        new { id = -3, TitleDescription = "Mr." }
                    );
        }
    }
}
