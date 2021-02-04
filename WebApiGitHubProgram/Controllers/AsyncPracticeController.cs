using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncPracticeController : Controller
    {
        [HttpGet]
        public async Task<long> Task1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Printing Task1 Value {0}", DateTime.UtcNow.ToString());
            Task2();
            Task3();
            Console.WriteLine("Printing Task2 value{0}", DateTime.UtcNow.ToString());
            var a = stopwatch.ElapsedMilliseconds;
            await Task.CompletedTask;
            return a;
        }
        private async Task Task2()
        {
            await Task.Delay(10000);
            Console.WriteLine("Printing Task2 Value{0}", DateTime.UtcNow.ToString());
        }
        private async Task Task3()
        {
            await Task.Delay(10000);
            Console.WriteLine("Printing Task3 Value{0}", DateTime.MinValue.ToLocalTime());
        }

    }
}
