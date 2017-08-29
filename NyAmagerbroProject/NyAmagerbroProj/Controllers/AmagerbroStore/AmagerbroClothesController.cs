using NyAmagerbroProj.Models;
using NyAmagerbroProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NyAmagerbroProj.Controllers
{
    public class AmagerbroClothesController : Controller
    {
        // GET: AmagerbroClothes
        private IAmagerbroClothesRep<AmagerbroClothesStore> amagerRepository = null;

        public AmagerbroClothesController()
        {
            this.amagerRepository = new AmagerbroClothesRep<AmagerbroClothesStore>();
        }

        // GET: Amagerbro
        public ActionResult Index()
        {
            var AmagerbroClothesStore = amagerRepository.GetAll();
            return View(AmagerbroClothesStore);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AmagerbroClothesStore AmagerbroClothesStore)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Insert(AmagerbroClothesStore);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagerbroClothesStore);
            }
        }

        public ActionResult Edit(int Id)
        {
            var amagerbroStore = amagerRepository.GetById(Id);
            return View(amagerbroStore);
        }

        [HttpPost]
        public ActionResult Edit(AmagerbroClothesStore AmagerbroClothesStore)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Update(AmagerbroClothesStore);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagerbroClothesStore);
            }
        }

        public ActionResult Details(int Id)
        {
            var AmagerbroClothesStore = amagerRepository.GetById(Id);
            return View(AmagerbroClothesStore);
        }

        public ActionResult Delete(int Id)
        {
            var amagerbroStore = amagerRepository.GetById(Id);
            return View(amagerbroStore);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var AmagerbroClothesStore = amagerRepository.GetById(Id);
            amagerRepository.Delete(Id);
            amagerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}