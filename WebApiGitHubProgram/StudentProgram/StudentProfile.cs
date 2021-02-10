using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.StudentProgram
{
    public class StudentProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string StudentName { get; set; }
        [Required][MaxLength(10)]
        public string FatherName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }
        public string PreviousSchoolName { get; set; }
        public decimal fee { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
