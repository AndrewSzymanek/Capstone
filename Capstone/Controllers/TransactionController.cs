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
            Transaction transactionToView = db.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
            return View(transactionToView);
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
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            Transaction transactionToEdit = db.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
            return View(transactionToEdit);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            Transaction transactionToDelete = db.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
            return View(transactionToDelete);
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(Transaction transaction)
        {
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
