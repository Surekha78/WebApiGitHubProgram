using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.MasterData.Marks
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Mark Mark { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mark = await _context.Marks
                .Include(m => m.StudentProfile).FirstOrDefaultAsync(m => m.Id == id);

            if (Mark == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mark = await _context.Marks.FindAsync(id);

            if (Mark != null)
            {
                _context.Marks.Remove(Mark);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
