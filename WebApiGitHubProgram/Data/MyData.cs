using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Data
{
    public class MyData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50), MinLength(3)]
        public string DataName { get; set; }
        public double Sal { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? JoiningDate { get; set; }
    }
}
