using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Fee
    {
        [Key]
        public int Id { get; set; }
        public int StudentProfileid { get; set; }
        public decimal PeePaid { get; set; }
        public DateTime PaidOn { get; set; }


        [ForeignKey("StudentProfileid")]
        public StudentProfile StudentProfile { get; set; }
    }
}
