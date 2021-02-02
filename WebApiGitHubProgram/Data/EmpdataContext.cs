using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class EmpdataContext: DbContext
    {

        
            public EmpdataContext(DbContextOptions<EmpdataContext> options)
                : base(options)
            {
            }

            public DbSet<WebApplication3.Data.EmpdataContext> Empdata{ get; set; }
    }
}


