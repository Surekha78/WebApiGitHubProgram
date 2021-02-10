using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.StudentProgram
{
    public class Total
    {
        public int Avg { get; set; }
        public int Sum { get; set; }
        [Required]
        public string Grade { get; set; }
    }
}
