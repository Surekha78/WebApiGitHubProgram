using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        public int StudentProfileid { get; set; }
        public int English { get; set; }
        public int Hindi { get; set; }
        public int Maths { get; set; }

        [ForeignKey("StudentProfileid")]
        public StudentProfile StudentProfile { get; set; }
    }
}
