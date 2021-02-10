using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Data
{
    public class Marks
    { //Int, long, double , decimal, DateTime, Short, etc... by default mandatory, if you want to specify as nullable
        //you have to suffix with ?
        // string is by default nullable, if you want to make string as mandatory you have add required annotation
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        [Range(0, 100)]
        public int English { get; set; }
       // [Required]
        [Range(0, 100)]
        public int Maths { get; set; }
       // [Required] except string everything by default required
        [Range(0, 100)]
        public int Science { get; set; }
        public int Avg { get; set; }
        public int? Total { get; set; }
        [Required]
        public string Grade { get; set; }
        public string UserName { get; set; }
    }
}
