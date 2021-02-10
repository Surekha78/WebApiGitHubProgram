using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.StudentProgram
{
    public class Fee
    {
        public int Id { get; set; }
        [ForeignKey("StudentProfile")]
        public int StudentId { get; set; }
        public virtual StudentProfile StudentProfile { get; set; }
        public Boolean PaidStatus { get; set; }


    }
}
