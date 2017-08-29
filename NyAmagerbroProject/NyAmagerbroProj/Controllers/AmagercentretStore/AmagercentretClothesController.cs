using NyAmagerbroProj.Models.AmagercentretStore;
using NyAmagerbroProj.Repository.AmagercentretRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NyAmagerbroProj.Controllers.AmagercentretStore
{
    public class AmagercentretClothesController : Controller
    {
        // GET: AmagerbroClothes
        private IAmagercentretClothesRep<AmagercentretClothes> amagerRepository = null;

        public AmagercentretClothesController()
        {
            this.amagerRepository = new AmagercentretClothesRep<AmagercentretClothes>();
        }

        // GET: AmagercentretClothes
        public ActionResult Index()
        {
            var AmagercentretClothes = amagerRepository.GetAll();
            return View(AmagercentretClothes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AmagercentretClothes AmagercentretClothes)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Insert(AmagercentretClothes);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagercentretClothes);
            }
        }

        public ActionResult Edit(int Id)
        {
            var AmagercentretClothes = amagerRepository.GetById(Id);
            return View(AmagercentretClothes);
        }

        [HttpPost]
        public ActionResult Edit(AmagercentretClothes AmagercentretClothes)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Update(AmagercentretClothes);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagercentretClothes);
            }
        }

        public ActionResult Details(int Id)
        {
            var AmagercentretClothes = amagerRepository.GetById(Id);
            return View(AmagercentretClothes);
        }

        public ActionResult Delete(int Id)
        {
            var AmagercentretClothes = amagerRepository.GetById(Id);
            return View(AmagercentretClothes);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var AmagercentretClothes = amagerRepository.GetById(Id);
            amagerRepository.Delete(Id);
            amagerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}