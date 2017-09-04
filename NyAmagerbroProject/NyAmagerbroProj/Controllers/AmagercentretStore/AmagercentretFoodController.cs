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
    public class AmagercentretFoodController : Controller
    {

        // GET: AmagerbroClothes
        private IAmagercentretFoodRep<AmagercentretFood> amagerRepository = null;
        private AmagerbroDbContext db = new AmagerbroDbContext();

        public AmagercentretFoodController()
        {
            this.amagerRepository = new AmagercentretFoodRep<AmagercentretFood>();
        }

        // GET: AmagercentretFood
        public ActionResult Index(string searchString)
        {
            //This line creates a LINQ query to select from my model class
            var food = from m in db.AmagercentretFood
                          select m;
            //If the searchString parameter contains a string, the title query is modified to filter
            //on the value of the search string, using the code below
            if (!string.IsNullOrEmpty(searchString))
            {
                food = food.Where(s => s.Navn.Contains(searchString));
            }
            return View(food);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AmagercentretFood AmagercentretFood)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Insert(AmagercentretFood);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagercentretFood);
            }
        }

        public ActionResult Edit(int Id)
        {
            var AmagercentretFood = amagerRepository.GetById(Id);
            return View(AmagercentretFood);
        }

        [HttpPost]
        public ActionResult Edit(AmagercentretFood AmagercentretFood)
        {
            if (ModelState.IsValid)
            {
                amagerRepository.Update(AmagercentretFood);
                amagerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(AmagercentretFood);
            }
        }

        public ActionResult Details(int Id)
        {
            var AmagercentretFood = amagerRepository.GetById(Id);
            return View(AmagercentretFood);
        }

        public ActionResult Delete(int Id)
        {
            var AmagercentretFood = amagerRepository.GetById(Id);
            return View(AmagercentretFood);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var AmagercentretFood = amagerRepository.GetById(Id);
            amagerRepository.Delete(Id);
            amagerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}