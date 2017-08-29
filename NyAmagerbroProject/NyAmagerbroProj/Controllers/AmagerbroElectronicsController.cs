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

        public AmagerbroElectronicsController()
        {
            this.amagerRepository = new AmagerbroElectronicsRep<AmagerbroElectronicsStore>();
        }

        // GET: Amagerbro
        public ActionResult Index()
        {
            var AmagerbroElectronicsStore = amagerRepository.GetAll();
            return View(AmagerbroElectronicsStore);
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