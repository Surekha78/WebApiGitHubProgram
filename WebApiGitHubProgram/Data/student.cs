using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Data
{
    public class student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int studentName { get; set; }
        public int TitleId { get; set; }
        [ForeignKey("TitleId")]
       public Title Title { get; set; }
    }
}
