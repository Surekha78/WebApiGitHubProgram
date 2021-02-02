using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication3
{
    public class Empdata
   
    {
        [Key]
            public int id { get; set; }

        [Required, StringLength(50), MinLength(3)]
            public string EmpName { get; set; }
            public DateTime? DOB { get; set; }
            public DateTime J_Date { get; set; }
    }
}



