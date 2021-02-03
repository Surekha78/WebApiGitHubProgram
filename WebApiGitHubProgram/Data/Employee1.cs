using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Data
{
    public class Employee1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; } // 1, 2, 3 ...
        public string EmployeeName { get; set; } // Ramesh, Suresh ...
        public int JobID { get; set; } 

        [ForeignKey("JobID")]
        public Job Job { get; set; }
    }
}
