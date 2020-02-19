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
    public class MechanicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mechanics
        public ActionResult Index()
        {
            return View(db.Mechanics.ToList());
        }

        // GET: Mechanics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic mechanic = db.Mechanics.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // GET: Mechanics/Create
        public ActionResult Create()
        {
            Mechanic mechanic = new Mechanic();
            return View(mechanic);
        }

        // POST: Mechanics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                mechanic.ApplicationId = userId;
                var foundMechanic = db.Users.Where(e => e.Id == mechanic.ApplicationId).FirstOrDefault();
                db.Mechanics.Add(mechanic);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View();
        }

        // GET: Mechanics/Edit/5
        [Authorize(Roles = "Mechanic")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic mechanic = db.Mechanics.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // POST: Mechanics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Mechanic")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "MechanicId,FirstName,LastName,Shop")] Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                mechanic.ApplicationId = userId;
                db.Entry(mechanic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Mechanics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic mechanic = db.Mechanics.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // POST: Mechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mechanic mechanic = db.Mechanics.Find(id);
            db.Mechanics.Remove(mechanic);
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

        protected RedirectToRouteResult btnConfrim_Click(object sender, EventArgs e)
        {
            return RedirectToAction("Edit");
        }

        public ActionResult FilteredSearch()
        {
            var userID = User.Identity.GetUserId();
            FilterMechanic filterView = new FilterMechanic();
            filterView.ListOfShops = new SelectList(new List<string> { null, "Masarati", "Porsche", "Mclaren", "Ducati", "Kawasaki", "Honda", "Yamaha" });
            filterView.SearchByZip = new SelectList(new List<string> { null, "Search by Zip" });
            var foundMechanic = db.Mechanics.Where(u => u.ApplicationId == userID).FirstOrDefault();
            filterView.mechanics = db.Mechanics.ToList();
            ViewBag.key = true;
            return View(filterView); //Change it to ratings or something after
        }

        public ActionResult FilteredSearch(FilterMechanic FilterView)
        {
            FilterMechanic filterView = new FilterMechanic();
            filterView.ListOfShops = new SelectList(new List<string> { null, "Masarati", "Porsche", "Mclaren", "Ducati", "Kawasaki", "Honda", "Yamaha" });
            filterView.SearchByZip = new SelectList(new List<string> { null, "Search by Zip" });
            string selectShop = FilterView.SelectedShop;
            string zip = FilterView.Zip;
            var Id = User.Identity.GetUserId();

            var foundMechanic = db.Mechanics.Where(a => a.ApplicationId == Id).FirstOrDefault();
            if (zip == "Search by Zip" && selectShop != null)
            {
                if (selectShop == null)
                {
                    filterView.mechanics = db.Mechanics.Where(a => a.Shop == selectShop && a.Zip == foundMechanic.Zip).ToList();
                }
                else
                {
                    filterView.mechanics = db.Mechanics.Where(a => a.Zip == zip).ToList();
                }
            }
            else if (zip == "Search by Zip" && selectShop == null)
            {
                filterView.mechanics = db.Mechanics.Where(a => a.Zip == foundMechanic.Zip && a.Shop == foundMechanic.Shop).ToList();
            }
            else if (selectShop == null && zip != null)
            {
                if (selectShop == null)
                {
                    filterView.mechanics = db.Mechanics.Where(a => a.Zip == zip).ToList();
                }
                else
                {
                    filterView.mechanics = db.Mechanics.Where(a => a.Shop == selectShop && a.Zip == zip).ToList();
                }
            }
            else
            {
                filterView.mechanics = db.Mechanics.ToList();
            }
            ViewBag.key = true;
            return View(filterView);
        }
    }
}