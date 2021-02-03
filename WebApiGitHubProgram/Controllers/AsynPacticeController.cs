using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsynPacticeController : Controller
    {
        [HttpGet]
        public async Task Task1()
        {
            Console.WriteLine("Printing Task1 Value {0}", DateTime.UtcNow.ToString());
            Task2();
            await Task.CompletedTask;
            
           
        }
        public async Task Task2()
        {
            await Task.Delay(10000);
            Console.WriteLine("Printing Task2 Value{0}", DateTime.UtcNow.ToString());
        }
    }   
}
