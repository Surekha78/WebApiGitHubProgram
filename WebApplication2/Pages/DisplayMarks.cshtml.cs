using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class DisplayMarksModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DisplayMarksModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }
        public class VMark: Mark
        {
            public int Total { get; set; }
            public string Result { get; set; }
            public string Grade { get; set; }

            public string StudentName { get; set; }
        }

        public VMark vMark = new VMark();

        public string error = null;

        public void OnGet()
        {
            var HallTicket = TempData["HallTicket"].ToString();
            var sid = _context.StudentProfiles.Where(w => w.HallTicket == HallTicket).Select(s => new { s.Id, s.StudentName }).FirstOrDefault();
            if (sid == null)
            {
                error = "Invalid Hall TIcet No.";
                return;
            }

            var hm = _context.Marks.Where(w => w.StudentProfileid == sid.Id).FirstOrDefault();

            if (hm == null)
            {
                error = "Absent (Marks Not Found).";
                return;
            }

            vMark.English = hm.English;
            vMark.Hindi = hm.Hindi;
            vMark.Maths = hm.Maths;
            vMark.StudentName = sid.StudentName;
            vMark.Total = vMark.English + vMark.Hindi + vMark.Maths;
        }
    }
}
