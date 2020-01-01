using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class ClientsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Clients
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                // TODO: Add insert logic here
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Create", "Jobs", client);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clients/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
