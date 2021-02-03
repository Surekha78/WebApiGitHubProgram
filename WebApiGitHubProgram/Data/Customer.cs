using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Data
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// Database will generate number by db
                                                             // [DatabaseGenerated(DatabaseGeneratedOption.None)] //Database will not generate
        public int CustId { get; set; }
        // [StringLength(50)] // [MinLength(3)]
        [Required, StringLength(50), MinLength(3)]
        public string CustName { get; set; }
        public string Location { get; set; }
        public DateTime? DOB { get; set; }  //suffix ? means it is nullable property
    }
}
