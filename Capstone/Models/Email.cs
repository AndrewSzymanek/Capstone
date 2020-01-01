using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Capstone.Models;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Net;

namespace Capstone.Models
{
    public class Email
    {

        [Required, Display(Name = "Email")]
        public string To { get; set; }

        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public void SendEmail()
        {
            MailMessage mc = new MailMessage(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), To);
            mc.Subject = Subject;
            mc.Body = Message;
            mc.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Timeout = 1000000;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            NetworkCredential nc = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mc);
        }

    }
}