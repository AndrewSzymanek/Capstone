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
    public class TaskMasterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Tasks
        public ActionResult Index(int id)
        {        
            var listoftask = db.Tasks.Where(s => s.JobId == id).ToList();
            return View(listoftask);
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(Task task, int id)
        {
            task.JobId = id;
            db.Tasks.Add(task);
            db.SaveChanges();
            return RedirectToAction("Index", "Jobs");
            
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            Task taskToEdit = db.Tasks.Where(t => t.TaskId == id).SingleOrDefault();
            return View(taskToEdit);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public ActionResult Edit(Task task)
        {
          
                if (ModelState.IsValid)
                {
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("JobsIndex", "Employees");
                }
                return RedirectToAction("Index", "Home");          
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tasks/Delete/5
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
