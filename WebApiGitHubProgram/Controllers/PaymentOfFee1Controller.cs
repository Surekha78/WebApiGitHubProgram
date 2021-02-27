using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGitHubProgram.Service;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
        public class PaymentOfFee1Controller : ControllerBase
        {
            [HttpGet]
            public IActionResult PaymentRecd()
            {
                // Storing the data and using your own buzz login goes here...


                // Sending Email
                // MyCommunicator myCommunicator = new MyCommunicator("UserName", "Password");
                MyCommunicator1 myCommunicator = new MyCommunicator1();
                myCommunicator.UserName = "UserName";
                myCommunicator.Password = "Password";
                myCommunicator.SendEmail();

                // Sending SMS
                myCommunicator.SendSMS();

                return NoContent();
            }

            [HttpGet("{id}")]
            public IActionResult PaymentRecd1(int id)
            {
            // Storing the data and using your own buzz login goes here...


            // Sending Email
            // MyCommunicator myCommunicator = new MyCommunicator("UserName", "Password");
            MyCommunicator1 myCommunicator = new MyCommunicator1();
                myCommunicator.UserName = "UserName";
                myCommunicator.Password = "Password";
                myCommunicator.SendEmail();

                // Sending SMS
                myCommunicator.SendSMS();

                return NoContent();
            }

            [HttpGet("{id}/{id1}")]
            public IActionResult PaymentRecd2(int id, int id1)
            {
            // Storing the data and using your own buzz login goes here...


            // Sending Email
            // MyCommunicator myCommunicator = new MyCommunicator("UserName", "Password");
            MyCommunicator1 myCommunicator = new MyCommunicator1();
                myCommunicator.UserName = "UserName";
                myCommunicator.Password = "Password";
                myCommunicator.SendEmail();

                // Sending SMS
                myCommunicator.SendSMS();

                return NoContent();
            }
        }
    }
}
