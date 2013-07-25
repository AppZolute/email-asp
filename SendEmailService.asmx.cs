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
    [WebService(Namespace = "http://www.w3.org/2001/XMLSchema")]
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
        public string SendEmail(string from, string to, string cc, string bcc, string subject, string body)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(from);

                if (to.Length > 0)
                {
                    string[] toEmails = to.Split(',');
                    for (int i = 0; i < toEmails.Length; i++)
                    {
                        message.To.Add(new MailAddress(toEmails[i]));
                    }
                }
                if (cc.Length > 0)
                {
                    string[] ccEmails = cc.Split(',');
                    for (int i = 0; i < ccEmails.Length; i++)
                    {
                        message.To.Add(new MailAddress(ccEmails[i]));
                    }
                }
                if (bcc.Length > 0)
                {
                    string[] bccEmails = bcc.Split(',');
                    for (int i = 0; i < bccEmails.Length; i++)
                    {
                        message.To.Add(new MailAddress(bccEmails[i]));
                    }
                }

                message.Subject = subject;
                message.Body = body;
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
