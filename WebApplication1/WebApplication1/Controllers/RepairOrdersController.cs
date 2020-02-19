using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class RepairOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RepairOrders
        public ActionResult Index(RepairOrder repair)
        {
            var repairs = db.RepairOrders;
            var userId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            var repairsC = db.RepairOrders.Where(r => r.VehicleNumber == customer.VehicleId);
            if (User.IsInRole("Mechanic"))
            {
                return View(repairs);
            }
            else if (User.IsInRole("Customer"))
            {
                return View(repairsC);
            }
            return View();
        }

        public ActionResult PartsAndLabor()
        {
            var repairs = db.RepairOrders;
            var userId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            var pLCustomer = db.RepairOrders.Where(p => p.VehicleNumber == customer.VehicleId);
            if (User.IsInRole("Mechanic"))
            {
                return View(repairs);
            }
            else if (User.IsInRole("Customer"))
            {
                return View(pLCustomer);
            }
            return View();
            

        }

        public ActionResult Create()
        {
            RepairOrder repairOrder = new RepairOrder();
            return View(repairOrder);
        }

        [HttpPost]
        public ActionResult Create( RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                db.RepairOrders.Add(repairOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairOrder);
        }

         public ActionResult CreatePL()
        {
            RepairOrder repairOrder = new RepairOrder();
            return View(repairOrder);
        }

        [HttpPost]
        public ActionResult CreatePL( RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                db.RepairOrders.Add(repairOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairOrder);
        }

        //public ActionResult PartsAndLabor()
        //{
        //    var Id = User.Identity.GetUserId();
        //    var foundRo = db.RepairOrders.Where(a => a.ApplicationId == Id).ToList();
        //    return View(foundRo);
        //}
        public ActionResult Details(RepairOrder repairOrder, Customer customer)
        {
            var vehicle = repairOrder.VehicleNumber;
            var repair = db.Customers.Where(c => c.VehicleId == vehicle).ToList().FirstOrDefault();
            db.SaveChanges();
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return HttpNotFound();
            }
            return View(repairOrder);
        }

        [HttpPost]
        public ActionResult Edit(int id, RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                var userId = User.Identity.GetUserId();
                repairOrder.ApplicationId = userId;
                db.Entry(repairOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public ActionResult EditPL(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return HttpNotFound();
            }
            return View(repairOrder);
        }

        [HttpPost]
        public ActionResult EditPL(int id, RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                var userId = User.Identity.GetUserId();
                repairOrder.ApplicationId = userId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public ActionResult DamagePicture()
        {
            var repairs = db.RepairOrders;
            var userId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            var pCustomer = db.RepairOrders.Where(p => p.VehicleNumber == customer.VehicleId);
            if (User.IsInRole("Mechanic"))
            {
                return View(repairs);
            }
            else if (User.IsInRole("Customer"))
            {
                return View(pCustomer);
            }
            return View();

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repair = db.RepairOrders.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: Mechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairOrder repair = db.RepairOrders.Find(id);
            db.RepairOrders.Remove(repair);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
