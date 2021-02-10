using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.StudentProgram
{
    public class Subject
    {
        public int English { get; set; }
         [Required]
        [Range(0, 100)]
        public int Maths { get; set; }
        
        [Range(0, 100)]
        public int Hindi { get; set; }
    }
}
