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
    public class EmployeesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employees
        public ActionResult Index()
        {

            return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details()
        {
            string employeeId = User.Identity.GetUserId();
            Employee employeeToGetDetails = db.Employees.Where(e => e.ApplicationId == employeeId).SingleOrDefault();
            return View(employeeToGetDetails);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var userLoggedIn = User.Identity.GetUserId();
                employee.ApplicationId = userLoggedIn;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit()
        {
            string employeeLoggedIn = User.Identity.GetUserId();
            Employee employeeToEdit = db.Employees.Where(e => e.ApplicationId == employeeLoggedIn).SingleOrDefault();
            return View(employeeToEdit);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {      
                if (ModelState.IsValid)
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", "Employees", employee);
                }
            return View();
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
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
