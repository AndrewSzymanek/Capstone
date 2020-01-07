using Capstone.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Google.Apis;

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
        public ActionResult JobsIndex()
        {
            string employeeId = User.Identity.GetUserId();
            Employee employeeToGet = db.Employees.Where(e => e.ApplicationId == employeeId).SingleOrDefault();
            Contractor boss = db.Contractors.Where(c => c.ContractorId == employeeToGet.ContractorId).SingleOrDefault();
            List<Transaction> transactionList = db.Transactions.Where(t => t.ContractorId == boss.ContractorId).ToList();
            List<Job> jobs = new List<Job>();
            foreach(Transaction transaction in transactionList)
            {
                Job job = db.Jobs.Where(j => j.JobId == transaction.JobId).SingleOrDefault();
                jobs.Add(job);
            }
           
            return View(jobs);
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
            Employee employee = new Employee();
            return View(employee);
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
            Employee employeeToDelete = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            return View(employeeToDelete);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //                   Below are methods to utilize Google Geolocation API when the app is hosted

        //[HttpPost]
        //public async Task<string> GetLatLong(Employee employee)
        //{
        //    var key = URLVariables.GeolocationKey;
        //    string url = $"https://www.googleapis.com/geolocation/v1/geolocate?key={key}";
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync(url);
        //    string jsonresult = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Geolocation latInfo = JsonConvert.DeserializeObject<Geolocation>(jsonresult);
        //        int Latitude = Convert.ToInt32(latInfo.lat);
        //        int Longitude = Convert.ToInt32(latInfo.lng);
        //        employee.Geolocation.Lat = Latitude.ToString();
        //        employee.Geolocation.Lng = Longitude.ToString();
        //        return employee.Geolocation.Lat;
        //    }
        //    string error = "Try again";
        //    return error;
        //}

        //public async System.Threading.Tasks.Task CompareToJobLocation(Job job, Employee employee)
        //{         
        //    await GetLatLong(employee);

        //}
        //public async System.Threading.Tasks.Task CheckIn(int id)
        //{
        //    DateTime todaysDate = new DateTime(); 
        //    string employeeLoggedIn = User.Identity.GetUserId();
        //    Employee employeeToCheckIn = db.Employees.Where(e => e.ApplicationId == employeeLoggedIn).SingleOrDefault();
        //    Job job = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();
        //    await CompareToJobLocation(job, employeeToCheckIn);           
        //    if (employeeToCheckIn.Geolocation.Lat == job.Lat && employeeToCheckIn.Geolocation.Lng == job.Long)
        //    {
        //        Day today = new Day();
        //        today.EmployeeId = employeeToCheckIn.EmployeeId;
        //        today.TodaysDate = todaysDate.Date.ToString();
        //        today.TimeIn = todaysDate.TimeOfDay.ToString();
        //        today.TimeOut = "to be determined";
        //        db.Days.Add(today);             
        //    }
        //}
        //public async System.Threading.Tasks.Task CheckOut(int id)
        //{
        //    DateTime todaysDate = new DateTime();
        //    string employeeLoggedIn = User.Identity.GetUserId();
        //    Employee employeeToCheckIn = db.Employees.Where(e => e.ApplicationId == employeeLoggedIn).SingleOrDefault();
        //    Job job = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();
        //    Day today = db.Days.Where(d => d.TodaysDate == todaysDate.Date.ToString()).Single();
        //    await CompareToJobLocation(job, employeeToCheckIn);
        //    if (employeeToCheckIn.Geolocation.Lat == job.Lat && employeeToCheckIn.Geolocation.Lng == job.Long)
        //    {
        //        today.TimeOut = todaysDate.TimeOfDay.ToString();
        //    }
        //}
        public async System.Threading.Tasks.Task<ActionResult> CheckIn(int id)
        {
            DateTime todaysDate = DateTime.Now;
            string employeeLoggedIn = User.Identity.GetUserId();
            Employee employeeToCheckIn = db.Employees.Where(e => e.ApplicationId == employeeLoggedIn).SingleOrDefault();
            Job job = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();
            Day today = new Day();
            today.EmployeeId = employeeToCheckIn.EmployeeId;
            today.TodaysDate = todaysDate.Date.ToString();
            today.TimeIn = todaysDate.TimeOfDay.ToString();
            today.CheckedIn = true;
            today.TimeOut = "to be determined";
            db.Days.Add(today);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async System.Threading.Tasks.Task<ActionResult> CheckOut(int id)
        {
            DateTime todaysDate = DateTime.Now;
            string employeeLoggedIn = User.Identity.GetUserId();
            Employee employeeToCheckOut = db.Employees.Where(e => e.ApplicationId == employeeLoggedIn).SingleOrDefault();
            Job job = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();
            Day today = db.Days.Where(d => d.CheckedIn == true).Where(d => d.EmployeeId == employeeToCheckOut.EmployeeId).SingleOrDefault();
            today.CheckedIn = false;
            today.TimeOut = todaysDate.TimeOfDay.ToString();
            DateTime timeIn = DateTime.Parse(today.TimeIn);
            DateTime timeOut = DateTime.Parse(today.TimeOut);
            double minutes = (timeOut.Subtract(timeIn).TotalMinutes);
            today.MinutesWorked = minutes;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
