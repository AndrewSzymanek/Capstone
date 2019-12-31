using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EmailIndex()
        {
            return View("EmailIndex");
        }
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> EmailIndex(EmailModel model)
        {
            using (var client = new HttpClient())
            {
                var Baseurl = Request.Url.GetLeftPart(UriPartial.Authority);

                //Passing service base url    
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format    
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service using HttpClient    
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/email/send-email", model);

                //Checking the response is successful or not which is sent using HttpClient    
                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }



}