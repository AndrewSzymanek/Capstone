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

        //// GET: Employees/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Employees/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, Employee employee)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public async Task<string> GetLat(Employee employee)
        {
            var key = URLVariables.GeolocationKey;
            string url = $"https://www.googleapis.com/geolocation/v1/geolocate?key={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Geolocation latInfo = JsonConvert.DeserializeObject<Geolocation>(jsonresult);
                employee.Geolocation.Lat = latInfo.lat.ToString();
                return employee.Geolocation.Lat;
            }
            string error = "Try again";
            return error;
        }
        public async Task<string> GetLong(Employee employee)
        {
            var key = URLVariables.GeolocationKey;
            string url = $"https://www.googleapis.com/geolocation/v1/geolocate?key={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Geolocation lngInfo = JsonConvert.DeserializeObject<Geolocation>(jsonresult);
                employee.Geolocation.Lng = lngInfo.lng.ToString();
                return employee.Geolocation.Lng;
            }
            string error = "Try again";
            return error;
        }
       
        public async System.Threading.Tasks.Task CompareToJobLocation(Job job)
        {
            string employeeLoggedIn = User.Identity.GetUserId();
            Employee employeeToCheckIn = db.Employees.Where(e => e.ApplicationId == employeeLoggedIn).SingleOrDefault();
            await GetLat(employeeToCheckIn);
            await GetLong(employeeToCheckIn);
            if(employeeToCheckIn.Geolocation.Lat == job.Lat && employeeToCheckIn.Geolocation.Lng == job.Long)
            {
                //check in for the day
                //change checkin bool to true
            }
        }
    }
}
