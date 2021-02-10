using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.ViewModel
{
    public class ViewMarks
    {
        public int Avg { get; set; }
        public int? Total { get; set; }
        [Required]
        public string Grade { get; set; }
    }
}
