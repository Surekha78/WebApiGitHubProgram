using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class ViewMarksModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public ViewMarksModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public string HallTicket { get; set; }

        public string ErrorMsg { get; set; }

        public void OnGet()
        {
        }

        public class ViewMark : Mark
        {
            public int Total { get; set; }
            public decimal Perc { get; set; }
            public string Result { get; set; }
            public string Grade { get; set; }
        }
             

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(HallTicket))
            {
                ErrorMsg = "Hall Ticet Not Entered...";
                return Page();
            }

            var sid = _context.StudentProfiles.Where(w => w.HallTicket == HallTicket).Select(s => s.Id).FirstOrDefault();

            var smarks = _context.Marks.Where(w => w.StudentProfileid == sid).FirstOrDefault();

            var viewMark = new ViewMark();
            viewMark.Id = smarks.Id;
            viewMark.StudentProfileid = smarks.StudentProfileid;
            viewMark.English = smarks.English;
            viewMark.Hindi = smarks.Hindi;
            viewMark.Maths = smarks.Maths;
            viewMark.Total = viewMark.English + viewMark.Hindi + viewMark.Maths;
            viewMark.Perc = viewMark.Total / 3;
            viewMark.Result = viewMark.English >= 35 && viewMark.Hindi >= 35 && viewMark.Maths >= 35 ? "P" : "F";
            viewMark.Grade = viewMark.Result == "P" && viewMark.Perc >= 60
                ? "A"
                : viewMark.Result == "P" && viewMark.Perc >= 50 && viewMark.Perc < 60
                ? "B"
                : viewMark.Result == "P" && viewMark.Perc >= 35 && viewMark.Perc < 50
                ? "C"
                : null;

            Console.WriteLine(viewMark);
            return Page();
        }
    }
}
