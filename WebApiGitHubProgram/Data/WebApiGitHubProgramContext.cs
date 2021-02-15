using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApiGitHubProgram.Exts;

using WebApiGitHubProgram.Data;
using System.ComponentModel.DataAnnotations.Schema;

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
            /*builder.Entity<Title>().HasKey(t => t.id); // BY ONE COL
            builder.Entity<Title>().HasKey(t => new { t.id, t.Name }); // BY TWO OR MORE COL. THIS IS NOT AVAIALABLE FOR DATA ANNOT
            builder.Entity<Title>().Property(t => t.TitleDescription).IsRequired(); // [Required]
            builder.Entity<Title>().Property(t => t.DepartmentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            builder.Entity<Title>().Property(t => t.TitleDescription).HasMaxLength(50); // [StringLength(50)]
            builder.Entity<Title>().Ignore(t => t.NoColName); // NoColName Only C# model but not for sql
            builder.Entity<Title>()
                .Property(t => t.TitleDescription)
                .HasColumnName("NewNameHere");

            builder.Entity<Title>()
                .HasRequired(c => c.Department)
                .WithMany(t => t.Courses)
                .Map(m => m.MapKey("ChangedFKID"));

            builder.Entity<Title>()
                .Property(p => p.TitleDescription)
                .HasColumnType("varchar");*/

            base.OnModelCreating(builder);
            builder.SeedMyDB();
        }

        public DbSet<MyTable> MyTables { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Student> Students { get; set; }

        public object Balutable { get; internal set; }
        public DbSet<WebApiGitHubProgram.Data.MyData> MyData { get; set; }

    }
}
