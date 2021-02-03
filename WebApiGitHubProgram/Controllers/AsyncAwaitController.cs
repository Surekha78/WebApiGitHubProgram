using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncAwaitController : ControllerBase
    {
        /*Test Purpose
       * private readonly WebApiGitHubProgramContext _context;
      public AsyncAwaitController(WebApiGitHubProgramContext context)
      {
          _context = context;
      }*/

        [HttpGet]
        public async Task<long> Method1()
        {
           // Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            Console.WriteLine("I just entered into Method1 {0}", DateTime.Now.ToString());
            Method2();
           // Method3();
           // Method4();
            Console.WriteLine("I ran after the Method2 call {0}", DateTime.Now.ToString());
            //stopwatch.Stop();
            //var a = stopwatch.ElapsedMilliseconds;
            //await Task.CompletedTask;
            return 0;
        }

        private async Task<int> Method2() // Email
        {
            Thread.Sleep(10000);
            await Task.Delay(10000);
            Console.WriteLine("I am running from within the Method2 {0}", DateTime.Now.ToString());
            return 10;
        }

        //private async Task Method3() // SMS
        //{
        //    // Thread.Sleep(10000);
        //    await Task.Delay(10000);
        //    Console.WriteLine("I am running from within the Method3 {0}", DateTime.Now.ToString());
        //    //return 10;
        //}

        //private async Task Method4() // DB Back up
        //{
        //    // Thread.Sleep(10000);
        //    await Task.Delay(10000);
        //    Console.WriteLine("I am running from within the Method4 {0}", DateTime.Now.ToString());
        //    //return 10;
        //}

    }
}

