using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public int SomeInt1 { get; set; }
        [BindProperty]
        public int SomeInt2 { get; set; }
        public string SomeName { get; set; }

        public void OnGet()
        {
            int i = 10;
            //i++;
            SomeInt1 = i;
            SomeName = $"Default value is : {i}";
        }

        public void OnPostInt1()
        {
            var a = SomeInt1;
            SomeName = a.ToString();
            Console.WriteLine(SomeInt1);
        }

        public void OnPostInt2()
        {
            var a = SomeInt2;
            SomeName = a.ToString();
            Console.WriteLine(SomeInt2);
        }

        public void OnPostInt3(int SomeInt3)
        {
            var a = SomeInt3;
            SomeName = a.ToString();
            Console.WriteLine(SomeInt3);
        }

        public IActionResult OnPostGenerateHallTickets()
        {
            var SList = _context.StudentProfiles.ToList();

            var FeePaidSum = _context.Fees.GroupBy(g => g.StudentProfileid)
                .Select(s => new
                {
                    StudentProfileid = s.Key,
                    PaidSum = s.Sum(s1 => s1.PeePaid)
                }).ToList();


            // var SortedSList = SList.OrderBy(o => o.StudentName).ToList();

            List<StudentProfile> SP4hall = new List<StudentProfile>();

            foreach (var s in SList)
            {
                var sFeePaidValue = FeePaidSum.Where(w => w.StudentProfileid == s.Id).Select(s => s.PaidSum).FirstOrDefault();
                if (sFeePaidValue >= s.PayableFee)
                {
                    SP4hall.Add(s);
                }
            }

            var SortedSList = SP4hall.OrderBy(o => o.StudentName).ToList();

            int i = 1;
            SortedSList.ForEach(s =>
            {
                s.HallTicket = $"H{i}";
                i++;
            });

            _context.SaveChanges();

            return RedirectToPage("/");

        }
    }
}
