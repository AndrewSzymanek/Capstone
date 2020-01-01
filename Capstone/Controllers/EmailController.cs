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
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Email email)
        {
            email.SendEmail();
            return RedirectToAction("Success", "Home");
        }


    }
}
