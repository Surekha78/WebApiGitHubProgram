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
    public class AsyncAwaitController1 : ControllerBase
    {
        [HttpGet]
        public async Task<int> Method1()
        {
            Console.WriteLine(" Now I am in Method1 {0}", DateTime.Now.ToString());
            Method2();
            Console.WriteLine("Now I am Going into Method2 call{0}", DateTime.Now.ToString());
            await Task.CompletedTask;
            return 10;
        }
        private async Task Method2()
        {
            //Thread.Sleep(10000);
            await Task.Delay(10000);
            Console.WriteLine("Now I am Going out From Method2 {0}", DateTime.Now.ToString());
            //return 10;

        }

       
    }
}
