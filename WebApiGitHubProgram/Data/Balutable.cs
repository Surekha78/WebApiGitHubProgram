using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGitHubProgram.Data
{
    public class Balutable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        
        [Required, StringLength(50), MinLength(3)]
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
        public DateTime? DOB { get; set; } 
        public DateTime? JoiningDate { get; set; }
        public String Address { get; set; }

    }
}
