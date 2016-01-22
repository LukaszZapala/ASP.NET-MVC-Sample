using FormsSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsSample.Controllers
{
    public class CatController : Controller
    {
        private static List<CatModel> catList;

        // Statyczny konstuktro wypełniający listę kociaków
        static CatController()
        {
            catList = new List<CatModel>();

            catList.Add(new CatModel { Id = 1, Name = "Puszek", Type = CatType.Dachowiec });
            catList.Add(new CatModel { Id = 2, Name = "Radek", Type = CatType.Pers });
            catList.Add(new CatModel { Id = 3, Name = "Adam", Type = CatType.Rosyjski });
            catList.Add(new CatModel { Id = 4, Name = "Ktoś", Type = CatType.Rufowiec });
            catList.Add(new CatModel { Id = 5, Name = "Cos", Type = CatType.Dachowiec });
            catList.Add(new CatModel { Id = 6, Name = "Kobus", Type = CatType.Rosyjski });
            catList.Add(new CatModel { Id = 7, Name = "Puszek", Type = CatType.Pers });
        }

        // GET: Cat
        public ActionResult Index()
        {
            // Przekazujemy listę kotów do widoku
            return View(catList);
        }

        //GET: Cat
        public ActionResult Details(int id)
        {
            var cat = catList.Find(x => x.Id == id);

            if (cat == null) return this.HttpNotFound();

            // Przekazujemy model
            return View(cat);
        }

        //GET: Cat
        public ActionResult Remove(int id)
        {
            var cat = catList.Find(x => x.Id == id);

            if (cat != null) catList.Remove(cat);

            // Powracamy do Index, czyli odświeżamy strone
            return RedirectToAction("Index");
        }

        //GET: Cat
        public ActionResult Add()
        {
            return View();
        }

        //POST: Cat
        [HttpPost]
        public ActionResult Add(CatModel cat)
        {
            cat.Id = catList.Count() + 1;
            catList.Add(cat);

            // Przekierowujemy się do Details
            return RedirectToAction("Details", new { id = cat.Id } );
        }
    }
}