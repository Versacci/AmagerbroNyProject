using NyAmagerbroProj.Models;
using NyAmagerbroProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NyAmagerbroProj.Controllers
{
    public class AmagerbroElectronicsController : Controller
    {
        // GET: AmagerbroElectronics
        private IAmagerbroElectronicsRep<AmagerbroElectronicsStore> amagerRepository = null;
        private AmagerbroDbContext db = new AmagerbroDbContext();

        public AmagerbroElectronicsController()
        {
            this.amagerRepository = new AmagerbroElectronicsRep<AmagerbroElectronicsStore>();
        }

        // GET: Amagerbro
        public ActionResult Index(string searchString)
        {
            //This line creates a LINQ query to select from my model class
            var electronics = from m in db.AmagerbroElectronicsStore
                          select m;
            //If the searchString parameter contains a string, the title query is modified to filter
            //on the value of the search string, using the code below
            if (!string.IsNullOrEmpty(searchString))
            {
                electronics = electronics.Where(s => s.Navn.Contains(searchString));
            }
            return View(electronics);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AmagerbroElectronicsStore AmagerbroElectronicsStore)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Insert(AmagerbroElectronicsStore);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagerbroElectronicsStore);
            }
        }

        public ActionResult Edit(int Id)
        {
            var AmagerbroElectronicsStore = amagerRepository.GetById(Id);
            return View(AmagerbroElectronicsStore);
        }

        [HttpPost]
        public ActionResult Edit(AmagerbroElectronicsStore AmagerbroElectronicsStore)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Update(AmagerbroElectronicsStore);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagerbroElectronicsStore);
            }
        }

        public ActionResult Details(int Id)
        {
            var AmagerbroElectronicsStore = amagerRepository.GetById(Id);
            return View(AmagerbroElectronicsStore);
        }

        public ActionResult Delete(int Id)
        {
            var AmagerbroElectronicsStore = amagerRepository.GetById(Id);
            return View(AmagerbroElectronicsStore);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var AmagerbroElectronicsStore = amagerRepository.GetById(Id);
            amagerRepository.Delete(Id);
            amagerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}