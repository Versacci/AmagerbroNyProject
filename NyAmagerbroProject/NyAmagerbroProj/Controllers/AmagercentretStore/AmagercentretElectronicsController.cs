using NyAmagerbroProj.Models.AmagercentretStore;
using NyAmagerbroProj.Repository.AmagercentretRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NyAmagerbroProj.Controllers.AmagercentretStore
{
    public class AmagercentretElectronicsController : Controller
    {
        // GET: AmagerbroClothes
        private IAmagercentretElectronicsRep<AmagercentretElectronics> amagerRepository = null;

        public AmagercentretElectronicsController()
        {
            this.amagerRepository = new AmagercentretElectronicsRep<AmagercentretElectronics>();
        }

        // GET: AmagercentretElectronics
        public ActionResult Index()
        {
            var AmagercentretElectronics = amagerRepository.GetAll();
            return View(AmagercentretElectronics);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AmagercentretElectronics AmagercentretElectronics)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Insert(AmagercentretElectronics);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagercentretElectronics);
            }
        }

        public ActionResult Edit(int Id)
        {
            var AmagercentretElectronics = amagerRepository.GetById(Id);
            return View(AmagercentretElectronics);
        }

        [HttpPost]
        public ActionResult Edit(AmagercentretElectronics AmagercentretElectronics)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Update(AmagercentretElectronics);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagercentretElectronics);
            }
        }

        public ActionResult Details(int Id)
        {
            var AmagercentretElectronics = amagerRepository.GetById(Id);
            return View(AmagercentretElectronics);
        }

        public ActionResult Delete(int Id)
        {
            var AmagercentretElectronics = amagerRepository.GetById(Id);
            return View(AmagercentretElectronics);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var AmagercentretElectronics = amagerRepository.GetById(Id);
            amagerRepository.Delete(Id);
            amagerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}