using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Service
{
    public class Branch1Communicator : IMyCommunicator1
    {
        

        void IMyCommunicator1.SendEmail()
            {
                Console.WriteLine("I am from Send Email - Branch 1");
            }

            void IMyCommunicator1.SendSMS()
            {
                Console.WriteLine("I am from Send SMS - Branch 1");
            }
        
    }
}
