using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDetailsController : ControllerBase
    {
       
        
            public List<Empdata> myEmps = new List<Empdata>();

            public EmpDetailsController()
            {
                myEmps.Add(item: new Empdata{ id = 1, EmpName = "Ramesh",  DOB = new DateTime(1988,3,4),J_Date=new DateTime(2003, 2, 2) });
                myEmps.Add(new Empdata { id = 2, EmpName = "Suresh", DOB = new DateTime(1998, 3, 5), J_Date = new DateTime(2001, 4, 4) });
                myEmps.Add(new Empdata { id = 2, EmpName = "Arun", DOB = new DateTime(1993, 3, 4), J_Date = new DateTime(2006, 5, 7) });
          }

            [HttpGet]
            public List<Empdata> GetEmps()
            {
                return myEmps;
            }

            [HttpGet("{id}")]
            public Empdata GetEmp(int id)
            {
                return myEmps.Where(w => w.id == id).FirstOrDefault();
            }

            [HttpGet("{date}/{dummy}")]
            public List<Empdata> GetEmp( DateTime date, string dummy)
            {
            return myEmps;
            }

            [HttpPut("{id}")]
            public List<Empdata> GetEmp([FromRoute] int id, [FromBody] Empdata myData)
            {
                var existingData = myEmps.Where(w => w.id != id).ToList();
                myEmps = myEmps.Where(w => w.id == -1).ToList(); // to remove all the records.

                myEmps.AddRange(existingData);
                myEmps.Add(myData);

                return myEmps;
            }

            [HttpPost]
            public List<Empdata> GetEmp([FromBody] Empdata myData)
            {
                myEmps.Add(myData);
                return myEmps;
            }

            [HttpDelete("{id}")]
            public List<Empdata> GetEmpDelete(int id)
            {
                myEmps = myEmps.Where(w => w.id != id).ToList();
                return myEmps;
            }


        }
    }



