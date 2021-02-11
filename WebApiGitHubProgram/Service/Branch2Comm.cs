using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Service
{
    public class Branch2Comm : IMyCommunicator
    {
        void IMyCommunicator.SendEmail()
        {
            Console.WriteLine("I am from Send Email - Branch 1");
        }

        void IMyCommunicator.SendSMS()
        {
            Console.WriteLine("I am from Send SMS - Branch 1");
        }
    }
}
