using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class ForHallTicketModel : PageModel
    {
        //ViewBag["Title"] = "Home page";
        //ViewData["Title"] = "Home page";

        //TempData["Title"] = "Home page";
        [BindProperty]
        public string HallTicket { get; set; }

        public MyClass myClass = new MyClass();

        public void OnGet()
        {
            myClass.name = "Ramesh Name HEre";
            
            ViewData["VDProperty"] = myClass;
            TempData["TDProperty"] = "Temp Data Value Here...";
        }

        public IActionResult OnPost()
        {
            TempData["HallTicket"] = HallTicket;

            return RedirectToPage("/DisplayMarks");

        }
    }
}
