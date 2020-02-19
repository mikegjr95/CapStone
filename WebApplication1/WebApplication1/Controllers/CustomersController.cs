using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Customers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            var customer = db.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var customerDetails = db.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            return View(customerDetails);
        }

        public ActionResult MechanicToViewCustomerDeatils(Customer customer)
        {
            return View(customer);
        }
        // GET: Customers/Create
        public ActionResult Create()
        {
            //ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Make");
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                var foundCustomer = db.Users.Where(e => e.Id == customer.ApplicationId).FirstOrDefault();
                db.Customers.Add(customer);
                db.SaveChanges();
                
                return RedirectToAction("Index","Home");
            }

            //ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "Make", customer.VehicleId);
            return View();
        }

        // GET: Customers/Edit/5
        [Authorize(Roles = "Customer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
