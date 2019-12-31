using Capstone.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    [System.Web.Http.RoutePrefix("api/email")]
    public class EmailController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("send-email")]
        public async System.Threading.Tasks.Task SendEmail([FromBody]JObject objData)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(objData["ToName"].ToString() + " <" + objData["ToEmail"].ToString() + ">"));
            message.From = new MailAddress("Andrew Szymanek <andrews@email.com>");
            message.Bcc.Add(new MailAddress("Andrew Szymanek <aszymanek@email.com>"));
            message.Subject = objData["Subject"].ToString();
            message.Body = CreateEmailBody(objData["ToName"].ToString(), objData["Message"].ToString());
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
                await System.Threading.Tasks.Task.FromResult(0);
            }
        }

        private string CreateEmailBody(string userName, string message)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/htmlTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Message}", message);
            return body;
        }

        
    }
}
