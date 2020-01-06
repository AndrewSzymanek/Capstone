using Capstone.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            string contractorUserId = User.Identity.GetUserId();
            Contractor contractorLoggedIn = db.Contractors.Where(c => c.ApplicationId == contractorUserId).SingleOrDefault();
            List<Transaction> transactionsToJobs = new List<Transaction>();
            foreach(Transaction transaction in db.Transactions)
            {
                if (transaction.ContractorId == contractorLoggedIn.ContractorId)
                {
                    transactionsToJobs.Add(transaction);
                }             
            }
            List<int> jobIds = new List<int>();
            foreach(Transaction transaction in transactionsToJobs)
            {
                jobIds.Add(transaction.JobId);
            }
            List<Job> contractorsJobs = new List<Job>();
            foreach(int jobId in jobIds)
            {
                Job contractorJob = db.Jobs.Where(j => j.JobId == jobId).FirstOrDefault();
                contractorsJobs.Add(contractorJob);
            }
            return View(contractorsJobs);
        }
        public ActionResult IndexCompletedJobs()
        {
            string contractorUserId = User.Identity.GetUserId();
            Contractor contractorLoggedIn = db.Contractors.Where(c => c.ApplicationId == contractorUserId).SingleOrDefault();
            List<Transaction> transactionsToJobs = new List<Transaction>();
            foreach (Transaction transaction in db.Transactions)
            {
                if (transaction.ContractorId == contractorLoggedIn.ContractorId)
                {
                    transactionsToJobs.Add(transaction);
                }
            }
            List<int> jobIds = new List<int>();
            foreach (Transaction transaction in transactionsToJobs)
            {
                jobIds.Add(transaction.JobId);
            }
            List<Job> contractorsJobs = new List<Job>();
            foreach (int jobId in jobIds)
            {
                Job contractorJob = db.Jobs.Where(j => j.JobId == jobId).FirstOrDefault();
                if(contractorJob.IsComplete == true)
                {
                    contractorsJobs.Add(contractorJob);
                }          
            }
            return View(contractorsJobs);
        }

        // GET: Jobs/Details/5
        public async Task<ActionResult> Details(int id)
        {
            
            Job jobToView = db.Jobs.Where(j => j.JobId == id).FirstOrDefault();
            jobToView.Weather = new Models.Weather();
            jobToView.Weather.Condition = await GetWeatherCondition(jobToView);
            jobToView.Weather.Temperature = await GetTemperature(jobToView);
            
            return View(jobToView);
        }
   

        // GET: Jobs/Create
        public ActionResult Create(Client client)
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        public async Task<ActionResult> Create(Job job, Client client)
        {
                Transaction transactionToAdd = new Transaction();
                string contractorId = User.Identity.GetUserId();
                Contractor contractorForTransaction = db.Contractors.Where(c => c.ApplicationId == contractorId).FirstOrDefault();
                int contractorIdForTransaction = contractorForTransaction.ContractorId;             
                transactionToAdd.ContractorId = contractorIdForTransaction;
                transactionToAdd.ClientId = client.ClientId;
                await GetLatLong(job);
                job.DateCompleted = null;
                db.Jobs.Add(job);
                transactionToAdd.JobId = job.JobId;
                db.Transactions.Add(transactionToAdd);           
                db.SaveChanges();
                return RedirectToAction("Index");
  
        }
        public async System.Threading.Tasks.Task GetLatLong(Job job)
        {
            string address = (job.StreetAddress + job.City + job.State);
            var key = URLVariables.GeoKey;
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                LatLongJsonInfo latLongJsonInfo = JsonConvert.DeserializeObject<LatLongJsonInfo>(jsonresult);
                var latlong = latLongJsonInfo.results[0].geometry.location;
                string lat = latlong.lat.ToString();
                string lng = latlong.lng.ToString();
                job.Lat = lat;
                job.Long = lng;
            }
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int id)
        {
            Job jobToEdit = db.Jobs.Where(j => j.JobId == id).FirstOrDefault();
            return View(jobToEdit);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                if(job.MaterialsCost != null && job.LaborCost != null && job.IsComplete != false)
                {
                    job.TotalLiabilities = (job.MaterialsCost + job.LaborCost);
                    job.ProfitabilityRatio = await CalculateProfitabilityRatio(job);
                    DateTime completionDate = DateTime.Now;
                    job.DateCompleted = completionDate;
                }             
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Jobs");
            }
            return RedirectToAction("Index", "Jobs");
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id)
        {
            Job jobToDelete = db.Jobs.Where(j => j.JobId == id).FirstOrDefault();
            return View(jobToDelete);
        }

        // POST: Jobs/Delete/5
        [HttpPost]
        public ActionResult Delete(Job job)
        {
                db.Jobs.Remove(job);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        public async Task<double?> CalculateProfitabilityRatio(Job job)
        {
            job.ProfitabilityRatio  = (job.PaymentReceived / job.TotalLiabilities);
            return job.ProfitabilityRatio;   
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
        public async Task<List<Job>> GetCompleteJobs()
        {
            string contractorUserId = User.Identity.GetUserId();
            Contractor contractorLoggedIn = db.Contractors.Where(c => c.ApplicationId == contractorUserId).SingleOrDefault();
            List<Transaction> transactionsToJobs = db.Transactions.Where(t => t.ContractorId == contractorLoggedIn.ContractorId).ToList();
            List<int> jobIds = new List<int>();
            foreach (Transaction transaction in transactionsToJobs)
            {
                jobIds.Add(transaction.JobId);
            }
            List<Job> contractorsJobs = new List<Job>();
            foreach (int jobId in jobIds)
            {
                Job contractorJob = db.Jobs.Where(j => j.JobId == jobId).FirstOrDefault();
                contractorsJobs.Add(contractorJob);
            }
            List<Job> completeJobs = contractorsJobs.Where(j => j.IsComplete == true && j.ProfitabilityRatio != null).ToList();
            return completeJobs;
        }
        public async Task<ActionResult> SeeProfits90Days()
        {
            DateTime now = DateTime.Now;
            List<Job> jobs = await GetCompleteJobs();           
            List<Job> jobsWithin90Days = jobs.Where(j => j.DateCompleted?.Day <= (now.Day - 90)).ToList();
            return View(jobsWithin90Days);
        }

        public async Task<ActionResult> SeeProfits6Months()
        {
            DateTime now = DateTime.Now;
            List<Job> jobs = await GetCompleteJobs();
            List<Job> jobsWithin6Months = jobs.Where(j => j.DateCompleted?.Day <= (now.Day - 180)).ToList();
            return View(jobsWithin6Months);
        }
        public async Task<ActionResult> SeeProfitsOneYear()
        {
            DateTime now = DateTime.Now;
            List<Job> jobs = await GetCompleteJobs();
            List<Job> jobsWithinOneYear = jobs.Where(j => j.DateCompleted?.Day <= (now.Day - 365)).ToList();
            return View(jobsWithinOneYear);
        }

    }
}
