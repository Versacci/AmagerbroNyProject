using NyAmagerbroProj.Models;
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
        private AmagerbroDbContext db = new AmagerbroDbContext();

        public AmagercentretClothesController()
        {
            this.amagerRepository = new AmagercentretClothesRep<AmagercentretClothes>();
        }

        // GET: AmagercentretClothes
        public ActionResult Index(string searchString)
        {
            //This line creates a LINQ query to select from my model class
            var clothes = from m in db.AmagerbrocentretClothes
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