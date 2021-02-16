using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Service
{
    public class MyCommunicator : IMyCommunicator
    {
        public string UserName = "Ramesh.Menta@live.com";
        public string Password = "fsdfdsfsd";

        private string Host = "smtp.gmail.com";
        private int Port = 587;
        private bool IsEnableSsl = true;

        /*public MyCommunicator(string UserName1, string Password1)
        {
            UserName = UserName1;
            Password = Password1;
        }*/

        /*public MyCommunicator()
        {
        }*/

        public void SendEmail()
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = UserName,
                        Password = Password
                    };

                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = IsEnableSsl;
                    client.Host = Host;
                    client.Port = Port;
                    client.UseDefaultCredentials = false;
                    client.Credentials = credential;

                    using (var msg = new MailMessage())
                    {
                        msg.From = new MailAddress("Ramesh.Menta@live.com", "MyInstitute Name");
                        msg.To.Add("ReceipientEmail@yahoo.com");
                        // msg.To.Add("ReceipientEmail1@yahoo.com");
                        msg.Subject = "My Attendance";
                        msg.IsBodyHtml = true;
                       //  msg.Body = "This is my body."; // string body
                        msg.Body = "<h1>This is my body.</h1>";
                        client.Send(msg);
                    }

                    Console.WriteLine("Email Successfully Sent.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public string SendSMS()
        {
            string strUrl = "http://pro.instabulksms.com/API/WebSMS/Http/v1.0a/index.php?username=<UserName>&password=<Password>&sender=<SenderID>&to=<RecipientMobile>&message=<MsgBody>&reqid=1&format={json|text}&route_id=route+id&callback=Any+Callback+URL&unique=0&sendondate=<SendDateTime>";
            WebRequest request = HttpWebRequest.Create(strUrl);
            string dataString = null;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader readStream = new StreamReader(response.GetResponseStream());
                dataString = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            catch (Exception ex)
            {
                dataString = ex.ToString().Length <= 100 ? ex.ToString() : ex.ToString().Remove(100);
            }
            return dataString;
        }
    }
}
