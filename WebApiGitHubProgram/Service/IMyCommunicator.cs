using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Service
{
    public interface IMyCommunicator
    {
        void SendEmail();

        void SendSMS();

    }
}
