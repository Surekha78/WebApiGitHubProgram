using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Data
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; } // 1, 2, 3 ...
        public string StudetName { get; set; } // Ramesh, Suresh ...
        public int TitleID { get; set; } // Mr. Mrs, Miss(, M/s) ...

        [ForeignKey("TitleID")]
        public Title Title { get; set; }
    }
}
