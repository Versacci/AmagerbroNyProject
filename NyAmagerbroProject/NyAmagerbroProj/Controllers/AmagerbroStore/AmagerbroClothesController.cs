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
        private AmagerbroDbContext db = new AmagerbroDbContext();

        public AmagerbroClothesController()
        {
            this.amagerRepository = new AmagerbroClothesRep<AmagerbroClothesStore>();
        }

        // GET: Amagerbro
        public ActionResult Index(string searchString)
        {
            //This line creates a LINQ query to select from my model class
            var clothes = from m in db.AmagerbroClothesStore
                        select m;
            //If the searchString parameter contains a string, the title query is modified to filter
            //on the value of the search string, using the code below
            if (!string.IsNullOrEmpty(searchString))
            {
                clothes = clothes.Where(s => s.Navn.Contains(searchString));
            }
            return View(clothes);
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