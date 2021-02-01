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
        public int StdId { get; set; }
        
        [Required, StringLength(50), MinLength(3)]
        public string StdName { get; set; }
        public double Fee { get; set; }
        public DateTime? DOB { get; set; } 
        public DateTime? JoiningDate { get; set; }
    }
}
