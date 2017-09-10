using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NyAmagerbroProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        public ActionResult GoogleMaps()
        {
            ViewBag.Message = "Google Maps";
            return View();
        }

        public ActionResult Renovation()
        {
            ViewBag.Message = "Renovation";
            return View();
        }

        public ActionResult Job()
        {
            ViewBag.Message = "Job";
            return View();
        }

        public ActionResult Lokale()
        {
            ViewBag.Message = "Lokale";
            return View();
        }
    }
}