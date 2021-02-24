using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Pages
{
    public class ControlsModel : PageModel
    {
        public class DDLClass
        {
            public int id { get; set; }
            public string DisplayName { get; set; }
        }

        public List<DDLClass> dDLClassData = new List<DDLClass>();

        public int id { get; set; }
        public string name { get; set; }
        public string SelectedName { get; set; }
        //public string[] names = new string[2] { get; set; }
        public bool isChecked { get; set; }
        public DateTime myDate { get; set; }
        public SelectList MyDDL { get; set; }
        public void OnGet()
        {
            id = 10;
            name = "Ramesh";
            //names[0] = "Ramesh";
            //names[1] = "Suresh";
            isChecked = true;
            myDate = DateTime.Now.Date;

            dDLClassData.Add(new DDLClass { id = 1, DisplayName = "Ramesh" });
            dDLClassData.Add(new DDLClass { id = 2, DisplayName = "Suresh" });

            MyDDL = new SelectList(dDLClassData, "id", "DisplayName");
        }
    }
}
