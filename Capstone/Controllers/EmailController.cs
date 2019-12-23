//using Capstone.Models;
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
    //public class EmailController : ApiController
    //{
    //    [System.Web.Http.HttpPost]
    //    [System.Web.Http.Route("send-email")]
    //    public async Task SendEmail([FromBody]JObject objData)
    //    {
    //        var message = new MailMessage();
    //        message.To.Add(new MailAddress(objData["ToName"].ToString() + " <" + objData["ToEmail"].ToString() + ">"));
    //        message.From = new MailAddress("Andrew Szymanek <andrews@email.com>");
    //        message.Bcc.Add(new MailAddress("Andrew Szymanek <aszymanek@email.com>"));
    //        message.Subject = objData["Subject"].ToString();
    //        message.Body = createEmailBody(objData["ToName"].ToString(), objData["Message"].ToString());
    //        message.IsBodyHtml = true;
    //        using (var smtp = new SmtpClient())
    //        {
    //            await smtp.SendMailAsync(message);
    //            await Task.FromResult(0);
    //        }
    //    }

    //    private string createEmailBody(string userName, string message)
    //    {
    //        string body = string.Empty;
    //        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/htmlTemplate.html")))
    //        {
    //            body = reader.ReadToEnd();
    //        }
    //        body = body.Replace("{UserName}", userName);
    //        body = body.Replace("{Message}", message);
    //        return body;
    //    }

    //    [System.Web.Http.HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Index(EmailModel model)
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            var Baseurl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));

    //            //Passing service base url    
    //            client.BaseAddress = new Uri(Baseurl);

    //            client.DefaultRequestHeaders.Clear();
    //            //Define request data format    
    //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //            //Sending request to find web api REST service using HttpClient    
    //            HttpResponseMessage Res = await client.PostAsJsonAsync("api/email/send-email", model);

    //            //Checking the response is successful or not which is sent using HttpClient    
    //            if (Res.IsSuccessStatusCode)
    //            {
    //                return View("Success");
    //            }
    //            else
    //            {
    //                return View("Error");
    //            }
    //        }
    //    }
    //    public ActionResult Success()
    //    {
    //        return View();
    //    }

    //    public ActionResult Error()
    //    {
    //        return View();
    //    }
    //}
}
