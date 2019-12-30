using Capstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class ContractorsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Contractors
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contractors/Details/5
        public ActionResult Details()
        {
            string contractorId = User.Identity.GetUserId();
            Contractor contractorToDetails = db.Contractors.Where(c => c.ApplicationId == contractorId).SingleOrDefault();
            return View(contractorToDetails);
        }

        // GET: Contractors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contractors/Create
        [HttpPost]
        public ActionResult Create(Contractor contractor)
        {
            try
            {
                var userLoggedIn = User.Identity.GetUserId();
                contractor.ApplicationId = userLoggedIn;
                db.Contractors.Add(contractor);
                db.SaveChanges();
                return RedirectToAction("Details", "Contractors", contractor);
            }
            catch
            {
                return View();
            }
        }

        // GET: Contractors/Edit/5
        public ActionResult Edit()
        {
            string contractorLoggedIn = User.Identity.GetUserId();
            Contractor contractorToEdit = db.Contractors.Where(c => c.ApplicationId == contractorLoggedIn).SingleOrDefault();
            return View(contractorToEdit);
        }

        // POST: Contractors/Edit/5
        [HttpPost]
        public ActionResult Edit(Contractor contractor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Contractors", contractor);
            }
            return View();
        }

        // GET: Contractors/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Contractors/Delete/5
        [HttpPost]
        public ActionResult Delete(Contractor contractor)
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
        public void SendInvoice()
        {

        }
    }
}
