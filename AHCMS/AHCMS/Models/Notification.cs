using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AHCMS.Models
{
    public class Notification
    {
        private string senderEmail = "tilakkhatri1087@gmail.com";
        private string senderPassword = "tilak1087";

        private void Mail(string SendTo, string Subject, string MailBody, HttpPostedFileBase attachment = null)
        {
            SendTo = "abhishek@syonsoftware.com";
            try
            {
                using (MailMessage mm = new MailMessage(senderEmail, SendTo))
                {
                    mm.Subject = Subject;
                    mm.Body = MailBody;
                    mm.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(senderEmail, senderPassword);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("alert('Please, check your network connection');");
            }
        }

        public void ForgotPasswordMail(string username, string password, string SendTo)
        {
            var Body = string.Format("" +
                "<div style='padding: 10px;'>Hi {0},</div>" +
                "<div style='padding:5px 10px;'>Your Password is {1}.</div>" +
                "<div>Thank You</div>", username, password);
            Mail(SendTo, "Forgot Password", Body);
        }
    }
}