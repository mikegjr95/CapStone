using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Review
        public ActionResult Index(string id, Mechanic mechanic)//For Check Others Reviews
        {

            var reviews = db.Reviews.Where(r => r.ApplicationId == id).ToList();
            ViewBag.reviedId = id;
            if (User.IsInRole("Customer"))
            {
                mechanic = db.Mechanics.Where(m => m.ApplicationId == id).FirstOrDefault();
                //ViewBag.MechanicId = mechanic.MechanicId;
            }
            return RedirectToAction("Index","Mechanics");
        }

        // GET: Review/Details/5
        public ActionResult Details(string id) //For Checking Your Reviews
        {
            var reviews = db.Reviews.Where(r => r.ApplicationId == id).ToList();
            return View(reviews);
        }

        // GET: Review/Create
        public ActionResult CreateR(string id)
        {
            Review review = new Review();
            return View(review);
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult CreateR(string id, Review review)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
                review.From = user.UserName;
                review.DatePosted = DateTime.Now;
                review.ApplicationId = id;
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index", review);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Rate(Review review)
        {
            if (User.IsInRole("Customer"))
            {
                ViewBag.key = "mus";
                return View(review);
            }
            if (User.IsInRole("Mechanic"))
            {
                ViewBag.key = "cus";
                return View(review);
            }
            return View(review);
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
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

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
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