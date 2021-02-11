using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudResultsController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public StudResultsController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }
    
         StudResult[] GetResult = new StudResult[]
         {
            new StudResult
            {
                RollNo =1, StudName = "Tejas",BoardName="Pune Univercity",M1=45,M2=56,M3=78,TotalMarks=179,Status="Pass"
                ,Greeting="Congratulation"

            },
            new StudResult
            {
                RollNo =2, StudName = "Jay",BoardName="Pune Univercity",M1=78,M2=89,M3=56,TotalMarks=223,Status="Pass"
                ,Greeting="Congratulation"

            },
             new StudResult
            {
                RollNo =3, StudName = "Mira",BoardName="Pune University",M1=40,M2=45,M3=43,TotalMarks=128,Status="Pass"
                ,Greeting="Congratulation"

            },
              new StudResult
            {
                RollNo =4, StudName = "rAMESH",BoardName="Pune Univercity",M1=23,M2=34,M3=35,TotalMarks=91,Status="Fail"
                ,Greeting="Better Luck next"

            },
      };

         [HttpGet("{RollNo}/{StudName}")]
          public ActionResult<StudResult> GetStudent(int id) // ,string name)

        {
    
                  var student = GetResult.FirstOrDefault((p) => p.RollNo == id);
                    //, p.StudName == name);
                     if (student == null)
                     {
                          return NotFound();
                     }
                     return Ok(student);

          }
    // public ActionResult<StudResult> GetStudent(string name,int id)//Ramesh/ramesh/RAMESH/RAMmSH/ramesh / ramesh/  ramesh  /
    // {
    //     //  var student = GetResult.FirstOrDefault((p) => p.StudName.ToLower().Trim() == name.ToLower().Trim());
    //    // var student = GetResult.FirstOrDefault((p) => p.StudName.Compare( name.ToLower().Trim()));
    //     .//var student = GetResult.FirstOrDefault((p) => string.Compare();
    //      // var student = StudResult.FirstOrDefault((p) =>p.Name==name, p.Id == id);
    //     if (student == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(student);
    // }
    // [HttpGet]
    //// public int ViewResult(int total)
    // { 


    //}
   }
}
