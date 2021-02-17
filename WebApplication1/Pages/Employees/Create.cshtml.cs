using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;

namespace WebApplication1.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public CreateModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Emp Emp { get; set; }

        [BindProperty]
        public string MyNewText { get; set; }

        private void ResetMyObj()
        {
            Emp.Id = 0;
            Emp.Name = "Type Your Name Here...";
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Emp.Add(Emp);
            await _context.SaveChangesAsync();


            // ResetMyObj(); 
            /*Emp.Id = 0;
            Emp.Name = "Type Your Name Here...";*/
            // return RedirectToPage("./Index");
            return Page();
        }
    }
}
