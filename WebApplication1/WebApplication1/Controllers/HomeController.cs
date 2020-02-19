using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexMoto()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult WelcomeM()
        {
            ViewBag.Message = "WelcomeM";
            return View();
            //            return RedirectToAction("Index", "Mechanics");
        }
        public ActionResult WelcomeC()
        {
            ViewBag.Message = "WelcomeC";

            return View();
        }

        public ActionResult WelcomeToWrenchIt()
        {
            ViewBag.Message = "WelcomeToWrenchIt";

            return View();
        }

    }
}