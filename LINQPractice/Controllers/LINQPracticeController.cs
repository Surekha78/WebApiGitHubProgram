using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQPracticeController : ControllerBase
    {
        private readonly DemodbContext _context;

        public LINQPracticeController(DemodbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLINQPractice()
        {
            // to get Generated SQL Statement
            var q = _context.OrderTbl.AsQueryable();
            var GeneratedSQL = q.ToQueryString(); // SELECT dbo.[c.Oid], c.CustomerId, c.Amount FROM Customers as c;
            
            // 1. SELECT * FROM Customers;

            // Method Query
            var am = _context.OrderTbl.ToList();

            // Query Syntax
            var aq = (from o in _context.OrderTbl select o).ToList();

            // 2. SELECT Country FROM Customers;
            var ocm = _context.OrderTbl.Select(s => s.Amount).ToList(); // List<int> = new List<int>();
            var ocq = (from o in _context.OrderTbl select o.Amount).ToList();

            // 3. SELECT Country,City,Name FROM Customers;
            var omm = _context.OrderTbl.Select(s => new { s.Oid, s.Amount, s.CustomerId });
            var omq = (from o in _context.OrderTbl select new { o.Oid, o.Amount, o.CustomerId }).ToList();

            // 4. SELECT * FROM Customers WHERE Country='Mexico';
            var owm = _context.DemoTbl
                .Where(w => w.Name == "Mexico").ToList();

            var owq = from demotbl in _context.DemoTbl
                      where demotbl.Name == "Mexico"
                      select demotbl;

            //5. SELECT * FROM Customers WHERE Country = 'Mexico' ORDER BY Country DESC;
            var om = _context.DemoTbl
                .Where(w => w.Name == "Mexico")
                .OrderBy(o => o.Id) // Asc
                // .OrderByDescending(o1 => o1.Id) // Desc
                .ToList();

            var oq = from demotbl in _context.DemoTbl
                     where demotbl.Name == "Mexico"
                     // orderby demotbl.Id // Asc
                     orderby demotbl.Id descending // DESC
                     select demotbl;

            // 6. SELECT Country FROM Customers ORDER BY Country DESC

            var ocom = _context.DemoTbl
                .Where(w => w.Name == "Mexico")
                .OrderBy(o => o.Id) // Asc
                .Select(s=>s.Name)
                .ToList();

            var ocoq = from demotbl in _context.DemoTbl
                       where demotbl.Name == "Mexico"
                       orderby demotbl.Id // Asc
                       select demotbl.Name;

            /* 7. SELECT COUNT(CustomerID), Country
                        FROM Customers
                                GROUP BY Country
                                HAVING COUNT(CustomerID) > 5;*/

            var ohm = (_context.DemoTbl.ToList()).Where(w => w.Name == "Mexico").ToList();
            var ohq = from x in (from d in _context.DemoTbl select d)
                      where x.Name == "Mexico"
                      select x;

            // 8. Select with Groupby Clause 
            /*SELECT COUNT(CustomerID), Country
            FROM Customers
            GROUP BY Country;*/

            var dgm = _context.DemoTbl
                .GroupBy(g => new { g.Id, g.Name })
                .ToList();

            var dgq = from d in _context.DemoTbl
                      group d by new
                      {
                          d.Id,
                          d.Name
                      } into x
                      select new
                      {
                          x.Key.Id,
                          x.Key.Name,
                          count = x.Count()
                      };











return Ok();
}
}
}
