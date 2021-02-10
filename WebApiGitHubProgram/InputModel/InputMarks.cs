using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.InputModel
{
    public class InputMarks
    {
        public int English { get; set; }
        // [Required]
        [Range(0, 100)]
        public int Maths { get; set; }
        // [Required] except string everything by default required
        [Range(0, 100)]
        public int Science { get; set; }
    }
}
