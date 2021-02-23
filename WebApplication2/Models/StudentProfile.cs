using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string FatehrName { get; set; }
        public DateTime DOB { get; set; }
        public string PreviousSchoolName { get; set; }
        public decimal PayableFee { get; set; }
        public string HallTicket { get; set; }

        public ICollection<Fee> Fee { get; set; }
        public ICollection<Mark> Mark { get; set; }
    }
}
