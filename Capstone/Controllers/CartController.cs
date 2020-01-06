using Capstone.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Capstone.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        } 
        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(string stripeToken)
        {
            StripeConfiguration.ApiKey = "sk_test_OcuHnDZ8Z69w3ZW3SvlthPnU00iV4dVHyt";

            // Token is created using Checkout or Elements!
            // Get the payment token submitted by the form:
            var token = stripeToken; // Using ASP.NET MVC
            //could save this token to a client's db info

            var options = new ChargeCreateOptions
            {
                Amount = 999,
                //change amount to the charge on a job object, etc!
                Currency = "usd",
                Description = "Example charge",
                Source = token,
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);

            var model = new ChargeViewModel();
            model.ChargeId = charge.Id;
            //could store this charge id on an invoice table for later reference and refunds

            return View("OrderStatus", model);
        }
    }
}
