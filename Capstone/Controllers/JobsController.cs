using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class JobsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Jobs
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        public ActionResult Create(Job job)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jobs/Edit/5
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

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: Jobs/Delete/5
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
        public ActionResult AddMaterialsCost()
        {
            //Job jobToAddMaterialsCost = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult AddMaterialsCost(Job job, double MaterialsCost)
        {
            Job jobToAddMaterialsCost = db.Jobs.Where(j => j.JobId == job.JobId).SingleOrDefault();
            jobToAddMaterialsCost.MaterialsCost += MaterialsCost;
            db.SaveChanges();
            return View("Index");
        }
    }
}
