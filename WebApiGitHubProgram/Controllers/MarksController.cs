using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Data;
using WebApiGitHubProgram.InputModel;
using WebApiGitHubProgram.ViewModel;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public MarksController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }


        [HttpGet]
        public int Add(InputMarks _marks)
        {
           // int? TotalMarks = 10;
            Console.WriteLine("Enter English marks: ", _marks.English);
            Console.WriteLine("Enter Sciecne marks: ", _marks.Science);
            Console.WriteLine("Enter Maths marks: ", _marks.Maths);
            Marks Table_mark = new Marks();
            Table_mark.English = _marks.English;
            Table_mark.Science = _marks.Science;
            Table_mark.Maths = _marks.Maths;
            Table_mark.Total = Table_mark.English + Table_mark.Science + Table_mark.Maths;
          Table_mark.Avg = (Table_mark.Total ??  0) / 3; // This is equivalent to collase operator

            //if(Table_mark.Avg > 50)
            //{
            //    Table_mark.Grade = "Pass";
            //}
            //else
            //{
            //    Table_mark.Grade = "Fail";
            //}
            //if (Table_mark.Avg > 50)
            //                Table_mark.Grade = "Pass";
            //else
            //    Table_mark.Grade = "Fail";
            Table_mark.Grade = (Table_mark.Avg > 50) ? "Pass" : "Fail";
            _context.Markss.Add(Table_mark);
            _context.SaveChanges();
            
            
            return Table_mark.Total ?? default;
           
      }
       // [HttpPost]
        /*public ActionResult<ViewMarks> Result(ViewMarks marks)
        {
            ViewMarks Show = new ViewMarks();
            Show.Grade = marks.Grade;
            Show.Total = marks.Total;
            Show.Avg = marks.Avg;
           
            _context.SaveChanges();
            if(Show.Grade == null)
            {
                return NotFound();
            }
            return Ok (marks);
        }
        */
        [HttpPost]
        public async Task<ActionResult> PostMarks(InputMarks inputModel)
        {
            Marks marks = new Marks();
            marks.English = inputModel.English;
            marks.Maths = inputModel.Maths;
            marks.Science = inputModel.Science;
            marks.Total = marks.English + marks.Maths + marks.Science;
            marks.Avg = marks.Total ?? 0 / 3;
            if (marks.Avg > 50)
                marks.Grade = "Pass";
            else
                marks.Grade = "Fail";
            marks.UserName = "David";
          int PK = marks.Id; //PK value is 0
            _context.Markss.Add(marks);

            await _context.SaveChangesAsync();
        //_context.SaveChanges();
            int PK2 = marks.Id; //PK value is somme value which is return my SQL
            return Ok(marks.Id);


        }
        [HttpGet("{Id}")]
        public IActionResult GetMarks(int Id)
        {
            // var MyRecord =  _context.Markss.Find(Id);
            var MyRecord = _context.Markss  // 100 records
                .Where(w => w.Id == Id) //10 records matches the wherre clause
                                        //     .ToList() //It fetch all the records that matches your where clause
                                        // .First() // out of 10 records it takes only first [0] number
                                        //.FirstOrDefault() //It will try to fetches [0] element if not it will return null
         // .Select(s => new { s.Id, s.Avg})
                .FirstOrDefault();

            if (MyRecord == null)
            {
                return NotFound();
            }
            else
                return Ok(MyRecord);

            
        }
    }
}
         

        
        
       