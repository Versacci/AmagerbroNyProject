using NyAmagerbroProj.Models;
using NyAmagerbroProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NyAmagerbroProj.Controllers
{
    public class AmagerbroFoodController : Controller
    {

        private IAmagerbroFoodRep<AmagerbroFoodStore> amagerRepository = null;

        public AmagerbroFoodController()
        {
            this.amagerRepository = new AmagerbroFoodRep<AmagerbroFoodStore>();
        }

        // GET: AmagerbroFood
        public ActionResult Index()
        {
            var AmagerbroFoodStore = amagerRepository.GetAll();
            return View(AmagerbroFoodStore);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AmagerbroFoodStore AmagerbroFoodStore)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Insert(AmagerbroFoodStore);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagerbroFoodStore);
            }
        }

        public ActionResult Edit(int Id)
        {
            var AmagerbroFoodStore = amagerRepository.GetById(Id);
            return View(AmagerbroFoodStore);
        }

        [HttpPost]
        public ActionResult Edit(AmagerbroFoodStore AmagerbroFoodStore)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Update(AmagerbroFoodStore);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagerbroFoodStore);
            }
        }

        public ActionResult Details(int Id)
        {
            var AmagerbroFoodStore = amagerRepository.GetById(Id);
            return View(AmagerbroFoodStore);
        }

        public ActionResult Delete(int Id)
        {
            var AmagerbroFoodStore = amagerRepository.GetById(Id);
            return View(AmagerbroFoodStore);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var AmagerbroFoodStore = amagerRepository.GetById(Id);
            amagerRepository.Delete(Id);
            amagerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}