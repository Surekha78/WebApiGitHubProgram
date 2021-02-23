using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class MyBuzzModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public MyBuzzModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}
