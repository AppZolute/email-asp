using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace EmailApi
{
    /// <summary>
    /// Summary description for SendEmailService
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SendEmailService : System.Web.Services.WebService
    {
        private string SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
        private string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"];
        private string SMTPUsername = ConfigurationManager.AppSettings["SMTPUsername"];
        private string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
        private string SMTPEnableSSL = ConfigurationManager.AppSettings["SMTPEnableSSL"];
 
        [WebMethod]
        public string SendEmail(string name)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress("info@app-zolute.com");
                message.To.Add(new MailAddress("angusluk@app-zolute.com"));
                message.Subject = "Test Email";
                message.Body = "Name: " + name;
                SmtpClient client = new SmtpClient(SMTPServer, Convert.ToInt16(SMTPPort))
                {
                    Credentials = new NetworkCredential(SMTPUsername, SMTPPassword),
                    EnableSsl = SMTPEnableSSL.Equals("yes")
                };
                client.Send(message);
            }
            return "success";
        }
    }
}
