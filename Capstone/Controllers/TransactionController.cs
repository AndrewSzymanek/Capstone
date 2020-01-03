using Capstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class TransactionController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChooseClient()
        {
            string contractorUserId = User.Identity.GetUserId();
            Contractor contractorLoggedIn = db.Contractors.Where(c => c.ApplicationId == contractorUserId).SingleOrDefault();
            List<Transaction> contractorTransactions = new List<Transaction>();
            foreach(Transaction transaction in db.Transactions)
            {
                if(transaction.ContractorId == contractorLoggedIn.ContractorId)
                {
                    contractorTransactions.Add(transaction);
                }
            }                   
            List<Client> clients = new List<Client>();
            foreach(Transaction transaction in contractorTransactions)
            {
                int clientId = transaction.ClientId;
                Client clientToAdd = db.Clients.Where(c => c.ClientId == clientId).Single();
                clients.Add(clientToAdd);
                
               
            }
            return View(clients);
        }
        [HttpPost]
        public ActionResult ChooseClient(string name)
        {
            Client clientWeWant = db.Clients.Where(c => c.LastName == name).FirstOrDefault();
            return RedirectToAction("Create", "Jobs", clientWeWant);
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            try
            {
                //string contractorId = User.Identity.GetUserId();
                //Contractor contractor = db.Contractors.Where(c => c.ApplicationId == contractorId).FirstOrDefault();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
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

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
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
