using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class DaysController : Controller
    {
        // GET: Days
        public ActionResult Index()
        {
            return View();
        }

        // GET: Days/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Days/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Days/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Days/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Days/Edit/5
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

        // GET: Days/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Days/Delete/5
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
