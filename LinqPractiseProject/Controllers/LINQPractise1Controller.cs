using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqPractiseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQPractise1Controller : ControllerBase
    {
    
        private readonly DemodbContext _context;

        public LINQPractise1Controller(DemodbContext context)
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
                .Select(s => s.Name)
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

            // Select with inner join

            /*SELECT Orders.OrderID, Customers.CustomerName,
							Orders.OrderDate
                           FROM Orders
                           INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;*/

            var jim = _context.OrderTbl
                .Join(_context.DemoTbl,
                pk => pk.Oid,
                fk => fk.Oid_id,
                (pk, fk) => new
                {
                    pk.Oid,
                    pk.Amount,
                    fk.Id,
                    fk.Name,
                    fk.Age
                }).ToList();

            var jiq = (from o in _context.OrderTbl
                       join d in _context.DemoTbl on o.Oid equals d.Oid_id
                       select new
                       {
                           o.Oid,
                           o.Amount,
                           d.Id,
                           d.Name,
                           d.Age
                       }).ToList();

            // little bit more opes with joins
            var jimMore = _context.OrderTbl
                .Join(_context.DemoTbl,
                pk => pk.Oid,
                fk => fk.Oid_id,
                (pk, fk) => new
                {
                    pk.Oid,
                    pk.Amount,
                    fk.Id,
                    fk.Name,
                    fk.Age
                })
                .Where(w => w.Age > 18)
                .OrderBy(o => o.Oid)
                .GroupBy(g => g.Name)
                /*.AsEnumerable()
                .ToArray() or .*/
                // Own Method/Function 
                .Select(s => new { s.Key, SumOfAmount = s.Sum(s1 => s1.Amount) })
                .Where(w => w.SumOfAmount > 1000)
                .ToList();

            // Select with Left join
            /*SELECT Customers.CustomerName, Orders.OrderID
                        FROM Customers
                        LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
                        ORDER BY Customers.CustomerName;*/

            var jl = (from o in _context.OrderTbl
                          // join d in _context.DemoTbl on o.Oid equals d.Oid_id // INNER JOIN
                      join t in _context.DemoTbl on o.Oid equals t.Oid_id into temp // Left Join
                      from d in temp.DefaultIfEmpty()
                      select new
                      {
                          o.Oid,
                          o.Amount,
                          d.Id,
                          d.Name,
                          d.Age
                      }).ToList();

            // RIGHT Join
            // THere is no such right join, simply need to reverse you table names from left join 
            var jr = (from d in _context.DemoTbl
                          // join d in _context.DemoTbl on o.Oid equals d.Oid_id // INNER JOIN
                      join t in _context.OrderTbl on d.Oid_id equals t.Oid into temp // Left Join
                      from o in temp.DefaultIfEmpty()
                      select new
                      {
                          o.Oid,
                          o.Amount,
                          d.Id,
                          d.Name,
                          d.Age
                      }).ToList();

            // Select with Full join
            /*SELECT Customers.CustomerName, Orders.OrderID
                        FROM Customers
                        FULL OUTER JOIN Orders ON Customers.CustomerID = Orders.CustomerID // CROSS Join
                        ORDER BY Customers.CustomerName;*/

            var jo = (from o in _context.OrderTbl
                      from d in _context.DemoTbl
                      select new
                      {
                          o.Oid,
                          o.Amount,
                          d.Name,
                          d.Age,
                          d.Oid_id
                      }).ToList();

            /*****************JOINS END ****************/

            // Select all with SALARY values that start with "200"
            // SELECT* FROM DemoTbl WHERE SALARY LIKE '200%';
            var gm = _context.DemoTbl.Where(w => w.Salary.ToString().StartsWith("200")).ToList();
            var gq = (from d in _context.DemoTbl
                      where d.Salary.ToString().StartsWith("200")
                      select d).ToList();

            var gm1 = _context.DemoTbl.Where(w => w.Salary >= 25000 && w.Age > 18).ToList();

            var gmA = _context.DemoTbl.Any(w => w.Salary >= 25000 && w.Age > 18);

            // Select with any values that have "sh" in any position-->
            string a = "Ramesh";
            a.ToLower().Contains("me".ToLower());


            // Select Top 3 Record by Condition
            var gmc = _context.DemoTbl.Where(w => w.Salary >= 25000 && w.Age > 18)
                .OrderBy(o => o.Oid_id)
                .Take(10)
                .ToList();

            // Select with only distinct (different) values.

            int[] Ages = { 10, 20, 10, 20, 30 };
            var AgesD = Ages.Where(w => w > 10).Distinct(); // 20 , 30

            // where clause with array
            int[] ids = { 11, 22, 33, 44, 55 };
            var gmc1 = _context.DemoTbl.Where(w => ids.Contains(w.Id))
             .OrderBy(o => o.Oid_id)
             .Take(10)
             .ToList();

            // In Between
            // w.Age >= 13 && w.Age <= 19 

            /*******************Code First Vs SQL Missing ********************************/
            /*
             * SQL              -    Code First
            1. Table Creation   -      Done
            2. View Creattion   -         N/A (Direct SQL Query)
            3. Constraints      -      Data Annotations, Fluent API
            4. Triggers         -       N/A, (We have write our own buzz login) // 
            5. Stored Procedures    -   N/A, in case of Dot net Core. In case of Dot Net Framework, older versions, some how uses stored procedures.
            6. User-Defined Function - C # Method.
            */

            // Middleware
            // Apache/MIT

            /* Traditional Queries
            using (var SQLConnection = new SQLConnection)
            {
            }*/

            var q1 = _context.OrderTbl.FromSqlRaw("SELECT * FROM ORDERTBL").ToList();

            var pkID = 10;
            var q2 = _context.OrderTbl.FromSqlInterpolated($"SELECT * FROM ORDERTBL as o where o.id == {pkID}").ToList();
            var q21 = _context.OrderTbl.FromSqlRaw("EXEC sp.StoredProcedureName").ToList();

            var q3 = _context.Database.ExecuteSqlRaw("DELETE FROM ORDERTBL");
            var q4 = _context.Database.ExecuteSqlInterpolated($"DELETE FROM ORDERTBL WHERE ORDERTBL.ID == {pkID}");


            // Middleware -- dapper

            // --- CORS, Identity/Membership/JWT

            return Ok();
        }
    }
}

