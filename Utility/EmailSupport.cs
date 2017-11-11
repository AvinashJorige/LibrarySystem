using System;
using System.Configuration;
using System.Net.Mail;

namespace Utility
{
    public class EmailSupport
    {
        public void sendMail(string recepientEmail, string subject, string body)
        {

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(new Cipher().Decrypt(ConfigurationManager.AppSettings["UserName"]));
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = new Cipher().Decrypt(ConfigurationManager.AppSettings["Host"]);
                smtp.EnableSsl = Convert.ToBoolean(new Cipher().Decrypt(ConfigurationManager.AppSettings["EnableSsl"]));
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = new Cipher().Decrypt(ConfigurationManager.AppSettings["UserName"]);
                NetworkCred.Password = new Cipher().Decrypt(ConfigurationManager.AppSettings["Password"]);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(new Cipher().Decrypt(ConfigurationManager.AppSettings["Port"]));
                smtp.Send(mailMessage);
            }
        }

    }
}
