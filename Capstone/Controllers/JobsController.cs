﻿using Capstone.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        public ActionResult Details(int id)
        {
            Job jobToView = db.Jobs.Where(j => j.JobId == id).FirstOrDefault();
            return View(jobToView);
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
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Edit(Job job)
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
        public ActionResult AddMaterialsCost(int id)
        {
            Job jobToAddMaterialsCost = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();
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

        public async Task<string> GetWeatherCondition(Job job)
        {
            string zipCodeSpecific = (job.ZipCode + ",us");
            var key = URLVariables.WeatherKey;
            string url = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCodeSpecific}&APPID={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
                WeatherViewModel weatherJsonInfo = JsonConvert.DeserializeObject<WeatherViewModel>(jsonresult);
                string currentWeather = weatherJsonInfo.weather[0].description;    
            return currentWeather;
        }
        public async Task<int> GetTemperature(Job job)
        {
            string zipCodeSpecific = (job.ZipCode + ",us");
            var key = URLVariables.WeatherKey;
            string url = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCodeSpecific}&APPID={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            WeatherViewModel weatherJsonInfo = JsonConvert.DeserializeObject<WeatherViewModel>(jsonresult);
            var temperature = weatherJsonInfo.main.temp;
            double temperatureWithDecimal = (1.8 * (temperature - 273)) + 32;
            int temperatureInFahrenheit = Convert.ToInt32(temperatureWithDecimal);
            return temperatureInFahrenheit;
        }
    }
}
