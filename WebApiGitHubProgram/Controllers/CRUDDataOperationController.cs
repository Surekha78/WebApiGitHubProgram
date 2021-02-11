using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CRUDDataOperationController : ControllerBase
    {
        
            private readonly WebApiGitHubProgramContext _context;
            // CRUD
            public CRUDDataOperationController(WebApiGitHubProgramContext context)
            {
                _context = context;
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Customer>>> GetAllRecords()
            {
                // R - Read ALL
                var Data = _context.Customer.AsNoTracking().ToList(); // LINQ - select * from MyTables
                var Data1 = await _context.Customer.ToListAsync(); // assume, 1 lac records. 1 Min Time
                var i = 10;
                Data[0].Location = "Hyd";
                _context.SaveChanges();
                // return Data;
                return Data1;

                // return await _context.MyTables.ToListAsync();
            }

            [HttpGet]
            public async Task<ActionResult<Customer>> GetRecordByID()
            {
                // R - Read record by PK property
                var r = _context.Customer.Find(10); // EF
                                                    // var r1 = await _context.MyTables.FindAsync(10);

                _context.Entry(r).State = EntityState.Detached;
                r.Location = "hyd";

                return r;
                // return await _context.MyTables.ToListAsync();
            }

            [HttpGet]
            public async Task<ActionResult> UpdateRecord()
            {
                // U - Update Single Record
                var r = _context.Customer.Find(10); // EF
                r.CustName = "So and so";
                r.Location = "hyd";

                await _context.SaveChangesAsync();

                return Ok();
                // return await _context.MyTables.ToListAsync();
            }

            [HttpGet]
            public async Task<ActionResult> UpdateAllRecord()
            {
                // U - Update Multiple Record
                var rs = await _context.Customer.ToListAsync();

                /*foreach (var r in rs)
                {
                    r.Salary = 1000;
                    r.DOB = DateTime.Now.Date;
                }

                foreach (var r in rs)
                    r.Salary = 1000;*/

                rs.ForEach(updateLocation => { updateLocation.Location = "Pune"; updateLocation.DOB = DateTime.Now.Date; });

                await _context.SaveChangesAsync();

                return Ok();
                // return await _context.MyTables.ToListAsync();
            }

            [HttpGet]
            public async Task<ActionResult> UpdateRecord1()
            {
                // U - Update Single Record
                var r = GetMyTableObj();

                _context.Entry(r).State = EntityState.Modified;

                // _context.MyTables.Update(r); // if PK is matched, it updates, otherwise, it creates.
                // _context.MyTables.UpdateRange(rs); // 

                await _context.SaveChangesAsync();

                return Ok();
                // return await _context.MyTables.ToListAsync();
            }

            [HttpGet]
            public async Task<ActionResult<MyTable>> DeleteRecord()
            {
                // D - Delete
                var r = _context.MyTables.Find(10); // EF

                _context.MyTables.Remove(r);
                await _context.SaveChangesAsync();

                return r;
                // return await _context.MyTables.ToListAsync();
            }

            [HttpGet]
            public async Task<ActionResult> DeleteRecordBySomeCondition()
            {
                // D - Delete Multiple
                var rs = await _context.Customer.Where(w => w.CustName.Contains("Ramesh")).ToListAsync();
                _context.Customer.RemoveRange(rs);

                await _context.SaveChangesAsync();

                return Ok();
                // return await _context.MyTables.ToListAsync();
            }



            public class ViewCustomerTableModel
            {
            public int CustId { get; set; }
           
           public string CustName { get; set; }
            public string Location { get; set; }
        }

            [HttpGet]
            public async Task<List<ViewCustomerTableModel>> GetRecordsByCustNameContains()
            {
                /*if (<Condition>) // Expression that should ulitimately either true or false.
                {
                    if ()
                    {

                    }
                } 
                else if ()
                {

                }*/

                // R - Read record by a property

                var r = await _context.Customer // 1 lac
                    .Where(w => w.CustName.Contains("Ramesh")) // 1000 
                    .Select(s => new ViewCustomerTableModel { CustId = s.CustId, CustName = s.CustName, Location = s.Location })
                    // .OrderBy // Ascending
                    .OrderByDescending(o => o.CustId)
                    // .ToList()
                    .ToListAsync();

                // sql equalent is 
                /*SELECT Id, EmpName, Salary
                FROM MyTables
                WHERE(EmpName LIKE N'%Ramesh%')
                ORDER BY Id DESC*/

                return r;

            }

            //private MyTable GetMyTableObj()
            //{
            //    var r = new MyTable()
            //    {
            //        Id = 0,
            //        EmpName = "Harish",
            //        Salary = 2000,
            //        DOB = Convert.ToDateTime("2010-01-01")
            //    };
            private Customer GetMyTableObj()
            {
                var r = new Customer()
                {
                    CustId = 0,
                    CustName = "Harish",
                    Location = "Pune",
                    DOB = Convert.ToDateTime("2010-01-01")
                };

                //if (2 == 2)
                //    r.Salary = r.Salary + 1000;

                return r;
            }

            [HttpPost]
            public async Task<IActionResult> SaveRecord()
            {
                // C - Create

                var r = new MyTable()
                {
                    Id = 0,
                    EmpName = "Harish",
                    Salary = 2000,
                    DOB = Convert.ToDateTime("2010-01-01")
                };

                MyTable myTable = new MyTable();
                myTable.Id = 0;
                myTable.EmpName = "Harish";
                myTable.Salary = 2000;
                myTable.DOB = Convert.ToDateTime("2010-01-01");

                _context.MyTables.Add(myTable); // EF
                _context.MyTables.Add(new MyTable { Id = 0, EmpName = "Ramesh1", Salary = 1000 }); // EF
                _context.MyTables.Add(GetMyTableObj());

                /********************************///////

                List<MyTable> myTables = new List<MyTable>();
                myTables.Add(r);
                myTables.Add(myTable);

                _context.Customer.AddRange(r); // EF
                await _context.SaveChangesAsync(); // EF

                return Ok();
                // return await _context.MyTables.ToListAsync();
            }

            // Annonymous Methods
            // => means LAMBDA
            /*1. (Input Params) =>  <Expression>;
               2. (Input Params) =>  {
                    Statement 1;
                    Statement 2;
                    Statement ...n;
                };*/
        }
    }
}
