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
    public class ClientsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Clients
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Contractor contractor = db.Contractors.Where(c => c.ApplicationId == userId).FirstOrDefault();
            List<Transaction> contractorsTransactions = db.Transactions.Where(t => t.ContractorId == contractor.ContractorId).ToList();
            List<int> clientIds = new List<int>();
            foreach(Transaction transaction in contractorsTransactions)
            {
                clientIds.Add(transaction.ClientId);
            }
            List<Client> clients = new List<Client>();
            foreach(int ClientId in clientIds)
            {
                Client client = db.Clients.Find(ClientId);
                clients.Add(client);
            }
            return View(clients);
        }

        public ActionResult GetClientInfo(int id)
        {
            Transaction transactionToJob = new Transaction();
            transactionToJob = db.Transactions.Where(j => j.JobId == id).SingleOrDefault();
            Client clientWeWant = db.Clients.Where(c => c.ClientId == transactionToJob.ClientId).SingleOrDefault();
            return RedirectToAction("Details", clientWeWant);
        }
        // GET: Clients/Details/5
        public ActionResult Details(Client client)
        {
            return View(client);
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
            Client clientToEdit = db.Clients.Where(c => c.ClientId == id).FirstOrDefault();
            return View(clientToEdit);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            Client clientToDelete = db.Clients.Where(c => c.ClientId == id).FirstOrDefault();
            return View(clientToDelete);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult Delete(Client client)
        {
            try
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
