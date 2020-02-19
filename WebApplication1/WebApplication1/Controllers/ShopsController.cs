using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ShopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Shops
        public ActionResult Index()
        {
            return View(db.Shops.ToList());
        }

        // GET: Shops/Details/5
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var shopDetails = db.Shops.Where(c => c.ShopId == id).FirstOrDefault();
            return View(shopDetails);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            Shop shop = new Shop();
            return View(shop);
        }

        // POST: Shops/Create
        [HttpPost]
        public ActionResult Create(Shop shop)
        {
            {
                if (ModelState.IsValid)
                {
                    db.Shops.Add(shop);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(shop);
            }

        }

        // GET: Shops/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        //POST: Shops/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Shop shop)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                var userId = User.Identity.GetUserId();
                shop.ApplicationId = userId;
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Shops/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Shops/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
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
        public ActionResult ShopOne()
        {
            return View();
        }
        public ActionResult ShopTwo()
        {
            return View();
        }
        public ActionResult ShopThree()
        {
            return View();
        }
    }
}
