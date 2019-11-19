using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using AbantwanaWebMaster.Model;
using System.Net.Mail;

using System.Net.Mime;
using System.IO;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
           
            return Task.Factory.StartNew(() =>
            {
                sendMail(message);
            });
        }
        public void CaptureEmail(string destination,string subject, string Body)
        {
            IdentityMessage message = new IdentityMessage();
            message.Body = Body;
            message.Destination = destination;
            message.Subject = subject;
            
            SendAsync(message);
        }
        public void sendMail(IdentityMessage message)
        {
             //= new IdentityMessage();
           

            MailMessage msg = new MailMessage();
            //if (message.Subject =="New Order Details")

            //{

            //    //string fileName = Path.GetFileName(fileUploader.FileName);

            //    msg.Attachments.Add(new Attachment());

            //}
            msg.From = new MailAddress("abantwanaweb@gmail.com");
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.Body = message.Body;
            //msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
           // msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("abantwanaweb@gmail.com", "#Account{2019}");
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;

            smtpClient.Send(msg);
        }
    }
}
