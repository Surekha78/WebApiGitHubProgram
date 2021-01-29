using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Controllers
{
     //[Route("api2")]
    // [Route("api1/[action]")]
    [Route("api/[controller]/[action]")]
    // api/MyBuzzLogic/Add1
    [ApiController]
    public class MyBuzzLogicController : ControllerBase
    {
        // pending...
        // CORS --> usually specific to Web API
        // Diff between Async and Non-Async
        // JWT --> JSON Web Token--> THis is for Athentication...

        // Meantime by Monday... 
        // https://www.tutorialsteacher.com/linq/linq-tutorials



        /*private readonly WebApiGitHubProgramContext _db;
        public MyBuzzLogicController(WebApiGitHubProgramContext context)
        {
            _db = context;
        }*/
        [Route("ReturnsSameValue/{a}")]
        // api/MyBuzzLogic/Add1/ReturnsSameValue/55
        public int Add(int a)
        {
            return a;
        }

        public class class1
        {
            public int a { get; set; }
        }

        [Route("SumOfTwoVals")]
        [HttpPost]
        public int Add1(class1 class1)
        {
            return class1.a;
        }
        /*
        [HttpDelete]
        public async Task<int> RemoveAllRecords()
        {
            var allRecs = _db.MyTables.ToList();
            _db.MyTables.RemoveRange(allRecs);
            await _db.SaveChangesAsync();

            return 10;

        }*/
    }
}
