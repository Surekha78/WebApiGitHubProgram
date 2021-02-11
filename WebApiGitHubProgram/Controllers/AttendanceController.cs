using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Service;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMyCommunicator _myCommunicator;
        public IConfiguration Configuration { get; }
        public AttendanceController(IMyCommunicator myCommunicator, IConfiguration configuration)
        {
            Configuration = configuration;
            _myCommunicator = myCommunicator;
           // myCommunicator.UserName = "UserName";
            // myCommunicator.Password = "Password";
        }

        [HttpGet]
        public IActionResult AttenAbs()
        {
            // var UserName = Configuration["Email:UserName"]; // s***@gmail.com
            var MyProperty = Configuration["MyProperty"];
            Console.WriteLine(MyProperty);
            _myCommunicator.SendEmail();
            _myCommunicator.SendSMS();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult AttenAbs1(int id)
        {
            _myCommunicator.SendEmail();
            _myCommunicator.SendSMS();
            return NoContent();
        }

        [HttpGet("{id}/{id1}")]
        public IActionResult AttenAbs2(int id, int id1)
        {
            _myCommunicator.SendEmail();
            _myCommunicator.SendSMS();
            return NoContent();
        }
    }
}
